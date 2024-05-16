using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ24_010_Auto_Focus_CCD.SQLite
{
    public class OnnxModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string path_model { get; set; }
        public string path_label { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public OnnxModel() { }

        public static void CreateTable()
        {
            string sql = @"
            CREATE TABLE IF NOT EXISTS onnx_model (
            `id` INTEGER NOT NULL,
            `name` TEXT NOT NULL,
            `path_model` TEXT NOT NULL,
            `path_label` TEXT NOT NULL,
            `created_at` TEXT NOT NULL,
            `updated_at` TEXT NOT NULL,
            PRIMARY KEY(`id` AUTOINCREMENT));
            ";

            SQLite.SQliteDataAccess.Execute(sql, null);
        }

        public static void DropTable()
        {
            string sql = "DROP TABLE IF EXISTS onnx_model";
            SQLite.SQliteDataAccess.Execute(sql, null);
        }

        public Dictionary<string, object> CreateParameters()
        {
            return new Dictionary<string, object>
            {
                { "@name", this.name },
                { "@path_model", this.path_model },
                { "@path_label", this.path_label },
                { "@created_at", this.created_at },
                { "@updated_at",  SQLite.SQliteDataAccess.GetDateTimeNow() }
            };
        }     

        public void Save(){
            string sql = @"
            INSERT INTO onnx_model (name, path_model, path_label, created_at, updated_at)
            VALUES (@name, @path_model, @path_label, @created_at, @updated_at);
            ";
            Dictionary<string, object> parameters = CreateParameters();
            parameters["@created_at"] =  SQLite.SQliteDataAccess.GetDateTimeNow();
            SQLite.SQliteDataAccess.Execute(sql, parameters);
        }

        public void Update(){
            string sql = @"
            UPDATE onnx_model SET name = @name, path_model = @path_model, path_label = @path_label, updated_at = @updated_at
            WHERE id = @id;
            ";
            Dictionary<string, object> parameters = CreateParameters();
            parameters["@id"] = this.id;
            parameters["@updated_at"] =  SQLite.SQliteDataAccess.GetDateTimeNow();
            SQLite.SQliteDataAccess.Execute(sql, parameters);
        }

        public void Delete(){
            string sql = "DELETE FROM onnx_model WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@id"] = this.id;
            SQLite.SQliteDataAccess.Execute(sql, parameters);
        }

        public static OnnxModel? Get(int id){
            string sql = "SELECT * FROM onnx_model WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@id"] = id;
            return SQLite.SQliteDataAccess.Query<OnnxModel>(sql, parameters).FirstOrDefault();
        }

        public static List<OnnxModel> GetAll(int limit = 1000){
            string sql = "SELECT * FROM onnx_model ORDER BY id DESC LIMIT " + limit;
            return SQLite.SQliteDataAccess.Query<OnnxModel>(sql);
        }

        public static OnnxModel? GetByName(string name){
            string sql = "SELECT * FROM onnx_model LIKE @name";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@name"] = @"%" + name + @"%";
            return SQLite.SQliteDataAccess.Query<OnnxModel>(sql, parameters).FirstOrDefault();
        }

        public static int Count(string name = ""){
            string sql = "SELECT COUNT(*) FROM onnx_model";
            if(name != string.Empty){
                sql += " LIKE @name";
            }
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@name"] = @"%" + name + @"%";
            return SQLite.SQliteDataAccess.Query<int>(sql, parameters).FirstOrDefault();
        }

        public static List<OnnxModel> Search(string name = "" , int start = 0, int limit =100, string order_by = " id desc")
        {
            string sql = "SELECT * FROM onnx_model WHERE name LIKE @name ORDER BY @order_by LIMIT @start, @limit";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["@name"] = @"%" + name + @"%";
            parameters["@start"] = start;
            parameters["@limit"] = limit;
            parameters["@order_by"] = order_by;
            return SQLite.SQliteDataAccess.Query<OnnxModel>(sql, parameters);
        }
    }
}
