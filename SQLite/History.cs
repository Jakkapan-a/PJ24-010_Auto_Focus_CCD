﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ24_010_Auto_Focus_CCD.SQLite
{
    public class History
    {
        public int id { get; set; }
        public string employee { get; set; }
        public string qr_code { get; set; }
        public string image_file { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public History(){}

        public static void CreateTable()
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS history (
                    id INTEGER NOT NULL,
                    employee TEXT,
                    qr_code TEXT,
                    image_file TEXT,
                    created_at TEXT,
                    updated_at TEXT,
                    PRIMARY KEY(id AUTOINCREMENT)
                );
            ";
            SQLite.SQliteDataAccess.Execute(sql,null);
        }

        public static void DropTable()
        {
            string sql = "DROP TABLE IF EXISTS history";
            SQLite.SQliteDataAccess.Execute(sql,null);
        }

        public Dictionary<string, object> CreateParameters()
        {
            return new Dictionary<string, object>
            {
                { "@employee", this.employee },
                { "@qr_code", this.qr_code },
                { "@image_file", this.image_file },
                { "@created_at", this.created_at },
                { "@updated_at", SQLite.SQliteDataAccess.GetDateTimeNow() }
            };
        }

        public void Save()
        {
            string sql = @"
                INSERT INTO history (employee, qr_code, image_file, created_at, updated_at)
                VALUES (@employee, @qr_code, @image_file, @created_at, @updated_at);
            ";
            Dictionary<string, object> parameters = CreateParameters();
            parameters["@created_at"] = SQLite.SQliteDataAccess.GetDateTimeNow();
            SQLite.SQliteDataAccess.Execute(sql, parameters);
        }

        public void Update()
        {
            string sql = @"
                UPDATE history
                SET employee = @employee,
                    qr_code = @qr_code,
                    image_file = @image_file,
                    updated_at = @updated_at
                WHERE id = @id;
            ";
            Dictionary<string, object> parameters = CreateParameters();
            parameters["@updated_at"] = SQLite.SQliteDataAccess.GetDateTimeNow();
            SQLite.SQliteDataAccess.Execute(sql, parameters);
        }

        public void Delete()
        {
            string sql = "DELETE FROM history WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@id"] = this.id;
            SQLite.SQliteDataAccess.Execute(sql, parameters);
        }

        public static List<History> GetHistories()
        {
            string sql = "SELECT * FROM history order by id desc limit 1000";
            return SQLite.SQliteDataAccess.Query<History>(sql, null);
        }

        public static History? Get(int id)
        {
            string sql = "SELECT * FROM history WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@id"] = id;
            return SQLite.SQliteDataAccess.Query<History>(sql, parameters).FirstOrDefault() ?? null;
        }

        public static int Count(string employee = "", string qr_code = "")
        {
            string sql = @"
                SELECT COUNT(*) FROM history";
            
            if(!string.IsNullOrEmpty(employee) || !string.IsNullOrEmpty(qr_code))
            {
                sql += " WHERE ";
                if(!string.IsNullOrEmpty(employee))
                {
                    sql += "employee = @employee";
                }
                if(!string.IsNullOrEmpty(qr_code))
                {
                    if(!string.IsNullOrEmpty(employee))
                    {
                        sql += " AND ";
                    }
                    sql += "qr_code = @qr_code";
                }
            }
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            if(!string.IsNullOrEmpty(employee))
            {
                parameters["@employee"] = employee;
            }
            if(!string.IsNullOrEmpty(qr_code))
            {
                parameters["@qr_code"] = qr_code;
            }

            return SQliteDataAccess.Query<int>(sql, parameters).FirstOrDefault();
        }

        public static List<History> Search(string employee = "", string qr_code = "", int start =0 , int limit = 100, string order_by = " id desc")
        {
            string sql = @"
                SELECT * FROM history";
            
            if(!string.IsNullOrEmpty(employee) || !string.IsNullOrEmpty(qr_code))
            {
                sql += " WHERE ";
                if(!string.IsNullOrEmpty(employee))
                {
                    sql += "employee = @employee";
                }
                if(!string.IsNullOrEmpty(qr_code))
                {
                    if(!string.IsNullOrEmpty(employee))
                    {
                        sql += " AND ";
                    }
                    sql += "qr_code = @qr_code";
                }
            }
            sql += " ORDER BY " + order_by + " LIMIT @start, @limit";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            if(!string.IsNullOrEmpty(employee))
            {
                parameters["@employee"] = employee;
            }
            if(!string.IsNullOrEmpty(qr_code))
            {
                parameters["@qr_code"] = qr_code;
            }
            parameters["@start"] = start;
            parameters["@limit"] = limit;
            return SQLite.SQliteDataAccess.Query<History>(sql, parameters);
        }
    }
}