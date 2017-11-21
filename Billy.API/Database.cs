using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.Sqlite;
using Billy.Models;


namespace Billy.API
{
    public class Database
    {
        public class Methods
        {
            string database;
            string table;
            public Methods(string db)
            {
                database = $"{db}.db";
                table = db;
            }

            public object GetFromId(long id, string field)
            {
                string connectionStr = $"Filename={database};";
                using (var connect = new SqliteConnection(connectionStr))
                {
                    connect.Open();
                    string commandText = $"SELECT {field} FROM {table} WHERE Id={id}";
                    var command = new SqliteCommand(commandText, connect);
                    var result = command.ExecuteScalar();
                    return result;
                }
            }

            public void EditField(long id, string field, object value)
            {         
                using (var connect = new SqliteConnection($"Filename={database};"))
                {
                    connect.Open();
                    string sql = $"UPDATE {table}  SET `{field}`='{value}' WHERE `Id`='{id}';";
                    var command = new SqliteCommand(sql, connect);
                    command.ExecuteNonQuery();
                }
            }

            public bool Check(long id)
            {
                using (var connect = new SqliteConnection($"Filename={database};"))
                {
                    connect.Open();
                    string sql = $"SELECT Is FROM {table} WHERE Id={id}";
                    var command = new SqliteCommand(sql, connect);
                    var reader = command.ExecuteReader();
                    bool response = reader.Read();
                    reader.Close();
                    return response;
                }        
            }

            public void Delete(long id)
            {
                using (var connect = new SqliteConnection($"Filename={database};"))
                {
                    connect.Open();
                    string sql = $"DELETE FROM {table} WHERE Id={id}";
                    var command = new SqliteCommand(sql, connect);
                    command.ExecuteNonQuery();
                }
            }

            public void Add(string fields, string values)
            {
                using (var connect = new SqliteConnection($"Filename={database};"))
                {
                    connect.Open();
                    string sql = $@"INSERT INTO {table} ({fields}) VALUES ({values});";
                    var command = new SqliteCommand(sql, connect);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
