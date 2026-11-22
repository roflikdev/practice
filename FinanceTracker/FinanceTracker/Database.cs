using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FinanceTracker
{
    public class Database
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["FinanceTracker"].ConnectionString;

        public DataTable GetOperations()
        {
            using (var connection = new SqlConnection(connectionString))
            using (var adapter = new SqlDataAdapter(@"
                SELECT o.Id, o.OperationDate, t.Name AS TypeName, o.Description,
                       CASE WHEN o.TypeId = 1 THEN o.Amount ELSE -o.Amount END AS Amount
                FROM dbo.Operations o
                JOIN dbo.OperationTypes t ON t.Id = o.TypeId
                ORDER BY o.OperationDate DESC, o.Id DESC", connection))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void AddOperation(int typeId, decimal amount, System.DateTime date, string description)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(@"
                INSERT INTO dbo.Operations (TypeId, Amount, OperationDate, Description)
                VALUES (@type, @amount, @date, @description)", connection))
            {
                command.Parameters.Add("@type", SqlDbType.Int).Value = typeId;
                var amountParameter = command.Parameters.Add("@amount", SqlDbType.Decimal);
                amountParameter.Precision = 12;
                amountParameter.Scale = 2;
                amountParameter.Value = amount;
                command.Parameters.Add("@date", SqlDbType.Date).Value = date.Date;
                command.Parameters.Add("@description", SqlDbType.NVarChar, 150).Value = description;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
