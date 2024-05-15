﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ24_010_Auto_Focus_CCD.SQLite
{
    public class SQliteDataAccess
    {
        public static List<T> GetAll<T>(string tableName, int limit = 100)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<T>("select * from " + tableName + " order by id desc limit " + limit, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<T> GetRow<T>(string sql)
        {
            return ExecuteQuery<T>(sql);
        }

        public static void Execute(string sql, Dictionary<string, object>? parameters)
        {
            using (IDbConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                con.Execute(sql, parameters);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            if (id == "Default")
            {
                return "Data Source=" + System.IO.Directory.GetCurrentDirectory() + "\\" + "Database/data.db;Version=3;";
            }
            return "Data Source=" + System.IO.Directory.GetCurrentDirectory() + "\\" + ConfigurationManager.ConnectionStrings[id];
        }

        public static string GetDateTimeNow()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static List<T> Query<T>(string sql, Dictionary<string, object>? parameters = null) => ExecuteQuery<T>(sql, parameters);

        public static bool IsExist(string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query(sql, new DynamicParameters());
                return output.ToList().Count > 0;
            }
        }

        private static List<T> ExecuteQuery<T>(string sql, Dictionary<string, object>? parameters = null)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                return cnn.Query<T>(sql, parameters == null ? new DynamicParameters() : parameters).ToList();
            }
        }
    }
}
