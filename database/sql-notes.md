# SQL notes

## Задание 01. Создание базы и таблиц

### SQL

```sql
USE master;
GO

IF DB_ID('PracticeDB') IS NOT NULL
BEGIN
    ALTER DATABASE PracticeDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE PracticeDB;
END
GO

CREATE DATABASE PracticeDB;
GO

USE PracticeDB;
GO

CREATE TABLE Departments (
    DepartmentId INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100) NOT NULL
);

CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY IDENTITY(1,1),
    EmployeeName NVARCHAR(100) NOT NULL,
    Salary DECIMAL(10,2) NOT NULL,
    HireDate DATE NOT NULL,
    DepartmentId INT NOT NULL,
    ManagerId INT NULL,
    CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentId)
        REFERENCES Departments(DepartmentId),
    CONSTRAINT FK_Employees_Manager FOREIGN KEY (ManagerId)
        REFERENCES Employees(EmployeeId)
);

CREATE TABLE Projects (
    ProjectId INT PRIMARY KEY IDENTITY(1,1),
    ProjectName NVARCHAR(100) NOT NULL,
    StartDate DATE NOT NULL
);

CREATE TABLE EmployeeProjects (
    EmployeeId INT NOT NULL,
    ProjectId INT NOT NULL,
    Hours INT NOT NULL DEFAULT 0,
    CONSTRAINT PK_EmployeeProjects PRIMARY KEY (EmployeeId, ProjectId),
    CONSTRAINT FK_EP_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
    CONSTRAINT FK_EP_Projects FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId)
);
GO

SELECT name AS TableName FROM sys.tables ORDER BY name;
SELECT name AS ForeignKeyName FROM sys.foreign_keys ORDER BY name;
```

### Результат

4 таблицы и 4 внешних ключа.

### Вывод

Создал базу и четыре связанные таблицы.

## Задание 02. INSERT: заполнение данными

### SQL

```sql
INSERT INTO Departments (DepartmentName) VALUES
    (N'Разработка'),
    (N'Аналитика'),
    (N'Тестирование'),
    (N'Менеджмент');
GO

INSERT INTO Employees (EmployeeName, Salary, HireDate, DepartmentId, ManagerId) VALUES
    (N'Анна Иванова', 65000, '2020-03-15', 1, NULL),
    (N'Пётр Сидоров', 72000, '2019-07-01', 1, NULL),
    (N'Мария Кузнецова', 55000, '2021-11-20', 1, NULL),
    (N'Иван Петров', 48000, '2023-02-10', 1, NULL),
    (N'Ольга Смирнова', 61000, '2020-09-05', 2, NULL),
    (N'Дмитрий Орлов', 58000, '2022-04-18', 2, NULL),
    (N'Елена Волкова', 52000, '2023-06-01', 2, NULL),
    (N'Сергей Морозов', 45000, '2021-12-12', 3, NULL),
    (N'Наталья Соколова', 43000, '2024-01-15', 3, NULL),
    (N'Алексей Лебедев', 90000, '2018-05-25', 4, NULL);
GO

UPDATE Employees SET ManagerId = 1 WHERE EmployeeId = 4;
UPDATE Employees SET ManagerId = 2 WHERE EmployeeId = 3;
UPDATE Employees SET ManagerId = 5 WHERE EmployeeId = 6;
UPDATE Employees SET ManagerId = 10 WHERE EmployeeId = 9;
GO

INSERT INTO Projects (ProjectName, StartDate) VALUES
    (N'CRM System', '2023-01-10'),
    (N'Mobile App', '2023-05-01'),
    (N'Data Warehouse', '2022-11-20'),
    (N'AI Assistant', '2024-02-01'),
    (N'Legacy Refactor', '2021-06-15');
GO

INSERT INTO EmployeeProjects (EmployeeId, ProjectId, Hours) VALUES
    (1, 1, 120), (1, 3, 80),
    (2, 1, 150), (2, 4, 60),
    (3, 2, 100), (4, 2, 90),
    (4, 5, 40), (5, 3, 110),
    (6, 3, 70), (6, 4, 50),
    (7, 2, 95), (8, 5, 130),
    (10, 4, 200), (10, 1, 30);
GO

SELECT COUNT(*) AS TotalDepartments FROM Departments;
SELECT COUNT(*) AS TotalEmployees FROM Employees;
SELECT COUNT(*) AS TotalProjects FROM Projects;
SELECT COUNT(*) AS TotalAssignments FROM EmployeeProjects;
```

### Результат

4 отдела, 10 сотрудников, 5 проектов и 14 назначений.

### Вывод

Добавил тестовые данные во все таблицы.

## Задание 03. SELECT и WHERE

### SQL

```sql
SELECT EmployeeName, Salary FROM Employees
WHERE Salary > 50000
ORDER BY EmployeeId;

SELECT EmployeeName, HireDate FROM Employees
WHERE YEAR(HireDate) = 2023
ORDER BY EmployeeId;

SELECT EmployeeName FROM Employees
WHERE EmployeeName LIKE N'А%'
ORDER BY EmployeeId;

SELECT EmployeeName FROM Employees
WHERE DepartmentId = 2
ORDER BY EmployeeId;

SELECT EmployeeName, Salary FROM Employees
WHERE Salary BETWEEN 40000 AND 60000
ORDER BY EmployeeId;
```

### Результат

1. Зарплата больше 50000 — 7 человек.
2. В 2023 году пришли Иван Петров и Елена Волкова.
3. На «А» — Анна Иванова и Алексей Лебедев.
4. Во втором отделе — 3 человека.
5. Зарплата 40000–60000 — у 6 человек.

### Вывод

WHERE помогает выбирать нужные строки.

## Задание 04. ORDER BY и TOP

### SQL

```sql
SELECT TOP (3) EmployeeName, Salary
FROM Employees
ORDER BY Salary DESC;

SELECT TOP (5) EmployeeName, HireDate
FROM Employees
ORDER BY HireDate ASC;

SELECT DepartmentId, EmployeeName, Salary
FROM Employees
ORDER BY DepartmentId ASC, Salary DESC;
```

### Результат

Топ-3 по зарплате: Алексей — 90000, Пётр — 72000, Анна — 65000.
По стажу первые: Алексей, Пётр, Анна, Ольга, Мария.
При сортировке по отделам сначала идут сотрудники отделов 1, 2, 3, 4.

### Вывод

TOP ограничивает список после сортировки.

## Задание 05. Агрегатные функции

### SQL

```sql
SELECT
    COUNT(*) AS EmployeeCount,
    SUM(Salary) AS TotalSalary,
    ROUND(AVG(Salary), 2) AS AverageSalary,
    MIN(Salary) AS MinSalary,
    MAX(Salary) AS MaxSalary
FROM Employees;

SELECT COUNT(*) AS SalaryOver50000
FROM Employees
WHERE Salary > 50000;
```

### Результат

Всего 10 человек. Сумма зарплат — 589000, средняя — 58900, минимум — 43000, максимум — 90000. Больше 50000 получают 7 человек.

### Вывод

Агрегаты считают общую статистику.

## Задание 06. GROUP BY по отделам

### SQL

```sql
SELECT
    DepartmentId,
    COUNT(*) AS EmployeeCount,
    ROUND(AVG(Salary), 2) AS AverageSalary,
    SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
ORDER BY AVG(Salary) DESC;
```

### Результат

Отдел 4: 1 человек, средняя 90000, сумма 90000.
Отдел 1: 4 человека, средняя 60000, сумма 240000.
Отдел 2: 3 человека, средняя 57000, сумма 171000.
Отдел 3: 2 человека, средняя 44000, сумма 88000.

### Вывод

GROUP BY собирает сотрудников по отделам.

## Задание 07. GROUP BY и HAVING

### SQL

```sql
SELECT DepartmentId, COUNT(*) AS EmployeeCount
FROM Employees
GROUP BY DepartmentId
HAVING COUNT(*) > 2
ORDER BY DepartmentId;

SELECT DepartmentId, ROUND(AVG(Salary), 2) AS AverageSalary
FROM Employees
GROUP BY DepartmentId
HAVING AVG(Salary) > 55000
ORDER BY DepartmentId;

SELECT DepartmentId, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
HAVING SUM(Salary) > 150000
ORDER BY DepartmentId;
```

### Результат

Больше двух сотрудников — отделы 1 и 2.
Средняя выше 55000 — отделы 1, 2 и 4.
Сумма выше 150000 — отделы 1 и 2.

### Вывод

HAVING фильтрует уже готовые группы.

## Задание 08. INNER JOIN

### SQL

```sql
SELECT e.EmployeeName, d.DepartmentName, e.Salary
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
ORDER BY d.DepartmentName, e.Salary DESC;
```

### Результат

10 строк. Аналитика: Ольга, Дмитрий, Елена; Менеджмент: Алексей; Разработка: Пётр, Анна, Мария, Иван; Тестирование: Сергей, Наталья.

### Вывод

INNER JOIN добавляет название отдела к сотруднику.

## Задание 09. LEFT JOIN

### SQL

```sql
SELECT e.EmployeeId, e.EmployeeName
FROM Employees e
LEFT JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
WHERE ep.EmployeeId IS NULL
ORDER BY e.EmployeeId;
```

### Результат

9 — Наталья Соколова. У неё нет назначений на проекты.

### Вывод

LEFT JOIN помог найти сотрудника без проекта.

## Задание 10. JOIN четырёх таблиц

### SQL

```sql
SELECT e.EmployeeName, d.DepartmentName, p.ProjectName, ep.Hours
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
INNER JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
INNER JOIN Projects p ON ep.ProjectId = p.ProjectId
ORDER BY d.DepartmentName, e.EmployeeName, p.ProjectName;
```

### Результат

14 назначений. Например:
- Анна Иванова — Разработка — CRM System — 120 часов;
- Дмитрий Орлов — Аналитика — AI Assistant — 50 часов;
- Алексей Лебедев — Менеджмент — AI Assistant — 200 часов;
- Сергей Морозов — Тестирование — Legacy Refactor — 130 часов.

### Вывод

Соединил четыре таблицы и получил список назначений.


## Задание 11. Self-join

### SQL

```sql
SELECT e.EmployeeName, m.EmployeeName AS ManagerName
FROM Employees e
LEFT JOIN Employees m ON e.ManagerId = m.EmployeeId
ORDER BY e.EmployeeId;
```

### Результат

У Ивана руководитель Анна, у Марии — Пётр, у Дмитрия — Ольга, у Натальи — Алексей. У остальных ManagerName = NULL.

### Вывод

LEFT JOIN показывает и тех, у кого нет руководителя.

## Задание 12. Подзапросы в WHERE

### SQL

```sql
SELECT EmployeeName, Salary
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees)
ORDER BY Salary DESC;

SELECT EmployeeName, Salary
FROM Employees
WHERE Salary = (SELECT MAX(Salary) FROM Employees);
```

### Результат

Выше средней зарплаты 58900 — Алексей, Пётр, Анна и Ольга. Максимальная зарплата у Алексея — 90000.

### Вывод

Подзапрос возвращает значение для условия WHERE.

## Задание 13. Подзапрос в SELECT

### SQL

```sql
SELECT e.EmployeeName, e.Salary, e.DepartmentId,
    (SELECT ROUND(AVG(e2.Salary), 2)
     FROM Employees e2
     WHERE e2.DepartmentId = e.DepartmentId) AS AvgSalary,
    ROUND(e.Salary - (SELECT AVG(e2.Salary)
                      FROM Employees e2
                      WHERE e2.DepartmentId = e.DepartmentId), 2) AS Difference
FROM Employees e
ORDER BY e.EmployeeId;
```

### Результат

Например, у Анны разница +5000, у Петра +12000, у Марии -5000. Для отдела 2 средняя зарплата 57000.

### Вывод

Среднюю можно посчитать отдельно для отдела каждого сотрудника.

## Задание 14. EXISTS и NOT EXISTS

### SQL

```sql
SELECT e.EmployeeId, e.EmployeeName
FROM Employees e
WHERE EXISTS (
    SELECT 1 FROM EmployeeProjects ep
    WHERE ep.EmployeeId = e.EmployeeId
)
ORDER BY e.EmployeeId;

SELECT e.EmployeeId, e.EmployeeName
FROM Employees e
WHERE NOT EXISTS (
    SELECT 1 FROM EmployeeProjects ep
    WHERE ep.EmployeeId = e.EmployeeId
)
ORDER BY e.EmployeeId;
```

### Результат

Первый запрос — 9 сотрудников. Второй — Наталья Соколова.

### Вывод

EXISTS проверяет наличие записей, NOT EXISTS — отсутствие.

## Задание 15. UNION и UNION ALL

### SQL

```sql
SELECT EmployeeName FROM Employees WHERE Salary > 60000
UNION
SELECT EmployeeName FROM Employees WHERE HireDate < '2022-01-01'
ORDER BY EmployeeName;

SELECT EmployeeName FROM Employees WHERE Salary > 60000
UNION ALL
SELECT EmployeeName FROM Employees WHERE HireDate < '2022-01-01'
ORDER BY EmployeeName;

SELECT COUNT(*) AS UnionCount FROM (
    SELECT EmployeeId FROM Employees WHERE Salary > 60000
    UNION
    SELECT EmployeeId FROM Employees WHERE HireDate < '2022-01-01'
) a;

SELECT COUNT(*) AS UnionAllCount FROM (
    SELECT EmployeeId FROM Employees WHERE Salary > 60000
    UNION ALL
    SELECT EmployeeId FROM Employees WHERE HireDate < '2022-01-01'
) a;
```

### Результат

UNION — 6 строк, UNION ALL — 10. Повторяются Анна, Пётр, Ольга и Алексей.

### Вывод

UNION убирает повторы, а UNION ALL их оставляет.

## Задание 16. UPDATE

### SQL

```sql
BEGIN TRANSACTION;

SELECT EmployeeId, EmployeeName, Salary, HireDate
FROM Employees ORDER BY EmployeeId;

UPDATE Employees SET Salary = Salary * 1.10
WHERE DepartmentId = 1;

UPDATE Employees SET Salary = Salary + 5000
WHERE HireDate < '2022-01-01';

UPDATE Employees SET HireDate = '2023-07-01'
WHERE EmployeeId = 7;

SELECT EmployeeId, EmployeeName, Salary, HireDate
FROM Employees ORDER BY EmployeeId;

ROLLBACK TRANSACTION;

SELECT EmployeeId, EmployeeName, Salary, HireDate
FROM Employees ORDER BY EmployeeId;
```

### Результат

Внутри транзакции у Анны 76500 вместо 65000, у Ивана 52800 вместо 48000. Дата Елены стала 2023-07-01. После ROLLBACK данные исходные.

### Вывод

Изменились только выбранные строки. Откатил изменения, чтобы не мешали следующим заданиям.

## Задание 17. DELETE

### SQL

```sql
BEGIN TRANSACTION;

INSERT INTO EmployeeProjects (EmployeeId, ProjectId, Hours)
VALUES (9, 1, 0);

SELECT COUNT(*) AS ZeroHoursCount FROM EmployeeProjects WHERE Hours = 0;
DELETE FROM EmployeeProjects WHERE Hours = 0;
SELECT COUNT(*) AS ZeroHoursCount FROM EmployeeProjects WHERE Hours = 0;

SELECT * FROM EmployeeProjects WHERE EmployeeId = 8;
DELETE FROM EmployeeProjects WHERE EmployeeId = 8;
SELECT COUNT(*) AS AssignmentsCount FROM EmployeeProjects;

SELECT * FROM Employees WHERE EmployeeId = 8;
DELETE FROM Employees WHERE EmployeeId = 8;
SELECT COUNT(*) AS EmployeesCount FROM Employees;

SELECT * INTO #EmployeesCopy FROM Employees;
SELECT COUNT(*) AS CopyCount FROM #EmployeesCopy;

DELETE FROM #EmployeesCopy WHERE EmployeeId = 1;
SELECT COUNT(*) AS CopyCount FROM #EmployeesCopy;

DELETE FROM #EmployeesCopy;
SELECT COUNT(*) AS CopyCount FROM #EmployeesCopy;

DROP TABLE #EmployeesCopy;
ROLLBACK TRANSACTION;

SELECT COUNT(*) AS EmployeesCount FROM Employees;
SELECT COUNT(*) AS AssignmentsCount FROM EmployeeProjects;
```

### Результат

Запись с 0 часами удалена. После удаления Сергея осталось 9 сотрудников и 13 назначений. В копии после DELETE без WHERE — 0 строк. После ROLLBACK снова 10 и 14.

### Вывод

Сначала удалил назначения сотрудника, чтобы не нарушить внешний ключ.
