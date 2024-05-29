using System;
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
        public string path_folder { get; set; }
        public int product_id { get; set; }
        public string model_name { get; set; } = "";
        public int voltage { get; set; }
        public int current { get; set; }
        public int onnx_model_id { get; set; } // model id 
        public string result { get; set; }
        public string re_judgment { get; set; }
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
                    path_folder TEXT,
                    product_id INTEGER,
                    model_name TEXT,
                    voltage INTEGER,
                    current INTEGER,
                    onnx_model_id INTEGER,
                    result TEXT,
                    re_judgment TEXT,
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
                { "@path_folder", this.path_folder },
                { "@product_id", this.product_id },
                { "@model_name", this.model_name },
                { "@voltage", this.voltage },
                { "@current", this.current },
                { "@onnx_model_id", this.onnx_model_id },
                { "@result", this.result },
                { "@re_judgment", this.re_judgment },
                { "@created_at", this.created_at },
                { "@updated_at", SQLite.SQliteDataAccess.GetDateTimeNow() }
            };
        }

        public void Save()
        {
            string sql = @"
                INSERT INTO history (employee, qr_code, path_folder, product_id, voltage, current, onnx_model_id, result, re_judgment, created_at, updated_at)
                VALUES (@employee, @qr_code, @path_folder, @product_id, @voltage, @current, @onnx_model_id, @result, @re_judgment, @created_at, @updated_at);
            ";
            Dictionary<string, object> parameters = CreateParameters();
            parameters["@created_at"] = SQLite.SQliteDataAccess.GetDateTimeNow();
            SQLite.SQliteDataAccess.Execute(sql, parameters);
        }

        public void Update()
        {
            string sql = @"
                UPDATE history SET employee = @employee, qr_code = @qr_code, path_folder = @path_folder, product_id = @product_id, voltage = @voltage, current = @current, onnx_model_id = @onnx_model_id, result = @result, re_judgment = @re_judgment, updated_at = @updated_at
                WHERE id = @id;
            ";
            Dictionary<string, object> parameters = CreateParameters();
            parameters["@id"] = this.id;
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

         public static int Count(string employee = "",  string model_name = "", string qr_code = "", string result = "", string re_judgment = "", string date = "")
         {
            string sql = "SELECT COUNT(*) FROM history WHERE employee LIKE @employee AND model_name LIKE @model_name AND qr_code LIKE @qr_code AND result LIKE @result AND re_judgment LIKE @re_judgment AND created_at LIKE @date";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@employee"] = @"%" + employee + @"%";
            parameters["@model_name"] = @"%" + model_name + @"%";
            parameters["@qr_code"] = @"%" + qr_code + @"%";
            parameters["@result"] = @"%" + result + @"%";
            parameters["@re_judgment"] = @"%" + re_judgment + @"%";
            parameters["@date"] = @"%" + date + @"%";
            return SQLite.SQliteDataAccess.Query<int>(sql, parameters).FirstOrDefault();
         }

        public static List<History> Search(string employee = "", string model_name = "", string qr_code = "", string result = "", string re_judgment = "", string date = "", int start = 0, int limit = 100, string order_by = " id desc")
        {
            string sql = "SELECT * FROM history WHERE employee LIKE @employee AND model_name LIKE @model_name AND qr_code LIKE @qr_code AND result LIKE @result AND re_judgment LIKE @re_judgment AND created_at LIKE @date ORDER BY @order_by LIMIT @start, @limit";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@employee"] = @"%" + employee + @"%";
            parameters["@model_name"] = @"%" + model_name + @"%";
            parameters["@qr_code"] = @"%" + qr_code + @"%";
            parameters["@result"] = @"%" + result + @"%";
            parameters["@re_judgment"] = @"%" + re_judgment + @"%";
            parameters["@date"] = @"%" + date + @"%";
            parameters["@start"] = start;
            parameters["@limit"] = limit;
            parameters["@order_by"] = order_by;
            
            return SQLite.SQliteDataAccess.Query<History>(sql, parameters);
        }
       
    }
}