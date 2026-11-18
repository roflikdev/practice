using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static string connectionString = Environment.GetEnvironmentVariable("PRACTICE_DB_CONNECTION") ?? "";

    static async Task Main()
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            Console.WriteLine("Не задана переменная PRACTICE_DB_CONNECTION.");
            return;
        }

        while (true)
        {
            Console.WriteLine("1. Список сотрудников");
            Console.WriteLine("2. Добавить сотрудника");
            Console.WriteLine("3. Отчёт по отделам");
            Console.WriteLine("0. Выход");
            string choice = Console.ReadLine() ?? "";
            if (choice == "0") break;

            try
            {
                if (choice == "1")
                {
                    await ShowEmployees();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Имя:");
                    string name = Console.ReadLine() ?? "";
                    Console.WriteLine("Зарплата:");
                    bool okSalary = decimal.TryParse(Console.ReadLine(), out decimal salary);
                    Console.WriteLine("Номер отдела:");
                    bool okDepartment = int.TryParse(Console.ReadLine(), out int departmentId);

                    if (string.IsNullOrWhiteSpace(name) || name.Length > 100 ||
                        !okSalary || salary <= 0 || salary > 99999999.99m ||
                        !okDepartment || departmentId <= 0)
                        Console.WriteLine("Неверные данные.");
                    else
                        await AddEmployee(name, salary, departmentId);
                }
                else if (choice == "3")
                {
                    ShowDepartments();
                }
                else
                {
                    Console.WriteLine("Нет такого пункта.");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    Console.WriteLine("Такого отдела нет.");
                else if (ex.Number == 50001 || ex.Number == 2601 || ex.Number == 2627)
                    Console.WriteLine("Такой сотрудник уже есть.");
                else
                    Console.WriteLine("Ошибка SQL: " + ex.Message);
            }
        }
    }

    static async Task ShowEmployees()
    {
        using SqlConnection connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        string sql = "SELECT EmployeeName, Salary FROM Employees ORDER BY EmployeeId";
        using SqlCommand command = new SqlCommand(sql, connection);
        using SqlDataReader reader = await command.ExecuteReaderAsync();

        bool found = false;
        while (await reader.ReadAsync())
        {
            Console.WriteLine(reader.GetString(0) + " - " + reader.GetDecimal(1));
            found = true;
        }
        if (!found) Console.WriteLine("Сотрудников нет.");
    }

    static async Task AddEmployee(string name, decimal salary, int departmentId)
    {
        using SqlConnection connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        string sql = @"
IF EXISTS (SELECT 1 FROM Employees WHERE EmployeeName = @name)
    THROW 50001, 'Такой сотрудник уже есть', 1;

INSERT INTO Employees (EmployeeName, Salary, HireDate, DepartmentId)
OUTPUT INSERTED.EmployeeId
VALUES (@name, @salary, CAST(GETDATE() AS DATE), @deptId);";

        using SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
        SqlParameter salaryParam = command.Parameters.Add("@salary", SqlDbType.Decimal);
        salaryParam.Precision = 10;
        salaryParam.Scale = 2;
        salaryParam.Value = salary;
        command.Parameters.Add("@deptId", SqlDbType.Int).Value = departmentId;

        int id = Convert.ToInt32(await command.ExecuteScalarAsync());

        using SqlCommand check = new SqlCommand(
            "SELECT EmployeeName, Salary, DepartmentId FROM Employees WHERE EmployeeId = @id", connection);
        check.Parameters.Add("@id", SqlDbType.Int).Value = id;
        using SqlDataReader reader = await check.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            Console.WriteLine("Добавлен: " + reader.GetString(0) + ", "
                + reader.GetDecimal(1) + ", отдел " + reader.GetInt32(2));
        }
    }

    static void ShowDepartments()
    {
        using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        string sql = @"SELECT d.DepartmentName, COUNT(e.EmployeeId) AS EmpCount,
    AVG(e.Salary) AS AvgSalary
FROM Departments d
LEFT JOIN Employees e ON d.DepartmentId = e.DepartmentId
GROUP BY d.DepartmentName
ORDER BY d.DepartmentName";

        using SqlCommand command = new SqlCommand(sql, connection);
        using SqlDataReader reader = command.ExecuteReader();

        Console.WriteLine("{0,-20} {1,10} {2,15}", "Отдел", "Сотрудники", "Средняя");
        bool found = false;
        while (reader.Read())
        {
            string average = reader.IsDBNull(2) ? "0" : reader.GetDecimal(2).ToString("0.00");
            Console.WriteLine("{0,-20} {1,10} {2,15}",
                reader.GetString(0), reader.GetInt32(1), average);
            found = true;
        }
        if (!found) Console.WriteLine("Отделов нет.");
    }

}
