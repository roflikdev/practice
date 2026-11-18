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
            Console.WriteLine("0. Выход");
            string choice = Console.ReadLine() ?? "";
            if (choice == "0") break;

            try
            {
                if (choice == "1")
                {
                    await ShowEmployees();
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

}
