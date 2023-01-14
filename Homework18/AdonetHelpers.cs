using Homework18.Adonet.Constants;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Homework18.Adonet
{
    public class AdonetHelpers
    {
        private const string Master = "master";
        private const string AdonetDbName = "adonetDb";
        private const string UsersTableName = "Users";
        private static string _connectionString = string.Format(ConfigurationHelper.LocalDbConnectionString, CreateNewAdonetDbIfNotExists());

        public static string CreateNewAdonetDbIfNotExists()
        {
            using (var sqlConnection = new SqlConnection(string.Format(ConfigurationHelper.LocalDbConnectionString, Master)))
            {
                var sqlQuery = "SELECT name, database_id, create_date  FROM sys.databases;";
                var sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                var table = dataSet.Tables[0];
                var listOfDbNames = new List<string>();

                foreach (DataRow row in table.Rows)
                {
                    listOfDbNames.Add(row["name"].ToString());
                }

                if (!listOfDbNames.Contains(AdonetDbName))
                {
                    sqlConnection.Open();

                    SqlCommand command = new SqlCommand();

                    // Identify command of new DB creation
                    command.CommandText = $"CREATE DATABASE {AdonetDbName}";

                    // Identify sql connection
                    command.Connection = sqlConnection;

                    // Execute query using ExecuteNonQuery which is used for INSERT, UPDATE, DELETE, CREATE commands
                    command.ExecuteNonQuery();
                }

                return AdonetDbName;
            }
        }

        public static string CreateUsersTableIfNotExists()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sqlQuery = "SELECT name FROM sys.tables;";
                var sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                var table = dataSet.Tables[0];
                var listOfTableNames = new List<string>();

                foreach (DataRow row in table.Rows)
                {
                    listOfTableNames.Add(row["name"].ToString());
                }

                if (!listOfTableNames.Contains(UsersTableName))
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand();

                    // Identify  command of new Table creation
                    command.CommandText = $"CREATE TABLE {UsersTableName} ({UsersTableColumns.Id} INT PRIMARY KEY IDENTITY, {UsersTableColumns.Age} INT NOT NULL, {UsersTableColumns.Name} NVARCHAR(100) NOT NULL, {UsersTableColumns.CreatedDate} DATETIME NOT NULL DEFAULT GETDATE());";

                    // Identify sql connection
                    command.Connection = sqlConnection;

                    // Execute query using ExecuteNonQuery which is used for INSERT, UPDATE, DELETE, CREATE commands
                    command.ExecuteNonQuery();
                }

                return UsersTableName;
            }
        }

        public static void AddEntryToTable(string name, int age)
        {
            var tableName = CreateUsersTableIfNotExists();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();

                // Identify  command of new Table creation
                command.CommandText = $"INSERT INTO {tableName} ({UsersTableColumns.Name}, {UsersTableColumns.Age}) VALUES ('{name}', {age})";

                // Identify sql connection
                command.Connection = sqlConnection;

                // Execute query using ExecuteNonQuery which is used for INSERT, UPDATE, DELETE, CREATE commands
                command.ExecuteNonQuery();
            }
        }

        public static void OutputAllTableData()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"SELECT * FROM {UsersTableName}";
                var sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                foreach (DataTable table in dataSet.Tables)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.WriteLine($"\t{column.ColumnName}");
                    }

                    foreach (DataRow row in table.Rows)
                    {
                        var cells = row.ItemArray;
                        foreach (DataRow cell in cells)
                        {
                            Console.WriteLine($"\t{cell}");
                        }
                    }
                }
            }
        }

        public static string GetLastAddedValueByRowIndexAndColumnName(string columnName)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"SELECT TOP(1) {UsersTableColumns.Id}, {UsersTableColumns.Name}, {UsersTableColumns.Age} FROM {UsersTableName} ORDER BY {UsersTableColumns.CreatedDate} DESC";
                var sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                var table = dataSet.Tables[0];

                return table.Rows[0][columnName].ToString();
            }
        }

        public static string GetValueByEntryIdAndColumnName(int entryId, string columnName)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"SELECT * FROM {UsersTableName} WHERE {UsersTableColumns.Id} = '{entryId}'";
                var sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                var table = dataSet.Tables[0];

                return table.Rows[0][columnName].ToString();
            }
        }

        public static List<string> GetListOfValuesByEntryColumnName(string columnName)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var listOfColumnValues = new List<string>();
                var sqlQuery = $"SELECT {columnName} FROM {UsersTableName}";
                var sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                var table = dataSet.Tables[0];

                foreach (DataRow row in table.Rows)
                {
                    listOfColumnValues.Add(row[columnName].ToString());
                }

                return listOfColumnValues;
            }
        }

        public static int AddNewEntryToTheTableUsingSqlDataUpdater(string nameValue, int ageValue)
        {
            var tableName = CreateUsersTableIfNotExists();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"SELECT * FROM {tableName}";
                var sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                var table = dataSet.Tables[0];

                // Add new row
                var newRow = table.NewRow();
                newRow[UsersTableColumns.Name] = nameValue;
                newRow[UsersTableColumns.Age] = ageValue;
                table.Rows.Add(newRow);

                // Save updates
                var commandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlDataAdapter.Update(dataSet);

                // Get local dataset reloaded
                dataSet.Clear();
                sqlDataAdapter.Fill(dataSet);
                var countOfAllEntries = table.Rows.Count;
                var idValueOfAddedEntry = table.Rows[countOfAllEntries-1][UsersTableColumns.Id];

                return Convert.ToInt32(idValueOfAddedEntry);
            }
        }

        public static void EditValueByEntryIdAndColumnName(int Id, string columnName, string value)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"SELECT * FROM {UsersTableName} WHERE {UsersTableColumns.Id} = '{Id}';";
                var sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                var table = dataSet.Tables[0];

                // Update data in certain row and column
                table.Rows[0][columnName] = value;

                // Save updates
                var commandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlDataAdapter.Update(dataSet);

                // Get local dataset reloaded
                dataSet.Clear();
                sqlDataAdapter.Fill(dataSet);
            }
        }

        public static void DeleteRowFromTableByRowIndex(int rowIndex)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"SELECT * FROM {UsersTableName}";
                var sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                var dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                var table = dataSet.Tables[0];

                // Delete row in dataset table by row index
                var rowToDelete = table.Rows[rowIndex];
                rowToDelete.Delete();

                // Save updates
                var commandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlDataAdapter.Update(dataSet);

                // Get local dataset reloaded
                dataSet.Clear();
                sqlDataAdapter.Fill(dataSet);
            }
        }
    }
}
