using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ24_010_Auto_Focus_CCD.SQLite
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int type { get; set; } // 0 = NONE, 1 = PVM
        public int voltage_min { get; set; }
        public int voltage_max { get; set; }
        public int amp_min { get; set; }
        public int amp_max { get; set; }
        public int onnx_model_id { get; set; } // model id 
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public Product() { }

        public static void CreateTable()
        {
            string sql = @"
            CREATE TABLE IF NOT EXISTS product (
            `id` INTEGER NOT NULL,
            `name` TEXT NOT NULL,
            `type` INTEGER NOT NULL,
            `voltage_min` INTEGER NOT NULL,
            `voltage_max` INTEGER NOT NULL,
            `amp_min` INTEGER NOT NULL,
            `amp_max` INTEGER NOT NULL,
            `onnx_model_id` INTEGER NOT NULL,
            `created_at` TEXT NOT NULL,
            `updated_at` TEXT NOT NULL,
            PRIMARY KEY(`id` AUTOINCREMENT));
            ";

            SQLite.SQliteDataAccess.Execute(sql,null);
        }

        public static void DropTable()
        {
            string sql = "DROP TABLE IF EXISTS product";
            SQLite.SQliteDataAccess.Execute(sql, null);
        }

        private Dictionary<string, object> CreateParameters()
        {
            return new Dictionary<string, object>
            {
                { "@name", this.name },
                { "@type", this.type },
                { "@voltage_min", this.voltage_min },
                { "@voltage_max", this.voltage_max },
                { "@amp_min", this.amp_min },
                { "@amp_max", this.amp_max },
                { "@onnx_model_id", this.onnx_model_id },
                { "@created_at", this.created_at },
                { "@updated_at", SQLite.SQliteDataAccess.GetDateTimeNow() }
            };
        }

        // Save
        public void Save()
        {
            string sql = @"
            INSERT INTO product (name, type, voltage_min, voltage_max, amp_min, amp_max, onnx_model_id, created_at, updated_at)
            VALUES (@name, @type, @voltage_min, @voltage_max, @amp_min, @amp_max, @onnx_model_id, @created_at, @updated_at);
            ";

            Dictionary<string, object> parameters = CreateParameters();
            parameters["@created_at"] = SQLite.SQliteDataAccess.GetDateTimeNow();
            SQLite.SQliteDataAccess.Execute(sql, parameters);
        }

        public OnnxModel GetOnnxModel()
        {
            return OnnxModel.Get(this.onnx_model_id);
        }
        public void Update()
        {
            string sql = @"
            UPDATE product
            SET name = @name, type = @type, voltage_min = @voltage_min, voltage_max = @voltage_max, amp_min = @amp_min, amp_max = @amp_max, onnx_model_id = @onnx_model_id, updated_at = @updated_at
            WHERE id = @id;
            ";

            Dictionary<string, object> parameters = CreateParameters();
            parameters["@id"] = this.id;
            SQLite.SQliteDataAccess.Execute(sql, parameters);
        }

        public void Delete()
        {
            string sql = "DELETE FROM product WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@id", this.id } };
            SQLite.SQliteDataAccess.Execute(sql, parameters);
        }

        public static List<Product> Get()
        {
            string sql = "SELECT * FROM product order by id desc limit 1000";
            return SQLite.SQliteDataAccess.GetRow<Product>(sql);
        }

        public static Product? Get(int id)
        {
            string sql = "SELECT * FROM product WHERE id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@id", id } };
            return SQLite.SQliteDataAccess.Query<Product>(sql, parameters).FirstOrDefault();
        }

        public static Product? Get(string name)
        {
            string sql = "SELECT * FROM product WHERE name = @name";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@name", name } };
            return SQLite.SQliteDataAccess.Query<Product>(sql, parameters).FirstOrDefault();
        }

        public static int Count(string? name = null)
        {
            string sql = "";
            if (name != null)
            {
                sql = "SELECT COUNT(*) FROM product LIKE @name";
                Dictionary<string, object> parameters = new Dictionary<string, object> { { "@name", $"%{name}%" } };
                return SQLite.SQliteDataAccess.Query<int>(sql, parameters).FirstOrDefault();
            }
            sql = "SELECT COUNT(*) FROM product";
            return SQLite.SQliteDataAccess.Query<int>(sql).FirstOrDefault();
        }

        public static List<Product> Search(string name)
        {
            string sql = "SELECT * FROM product WHERE name LIKE @name";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@name", $"%{name}%" } };
            return SQLite.SQliteDataAccess.Query<Product>(sql, parameters);
        }

         public static List<Product> Search(string name, int start, int limit , string order_by =  "id desc"){
            string sql = "SELECT * FROM product WHERE name LIKE @name ORDER BY @order_by LIMIT @start, @limit";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@name", $"%{name}%" }, { "@start", start }, { "@limit", limit }, { "@order_by", order_by } };
            return SQLite.SQliteDataAccess.Query<Product>(sql, parameters);
         }

         public static List<Product> Search(int start, int limit, string order_by = "id desc")
         {
            string sql = "SELECT * FROM product ORDER BY @order_by LIMIT @start, @limit";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@start", start }, { "@limit", limit }, { "@order_by", order_by } };
            return SQLite.SQliteDataAccess.Query<Product>(sql, parameters);
         }

         public static bool IsNameExist(string name, int id = -1)
         {
            string sql = "SELECT COUNT(*) FROM product WHERE name = @name";
            if (id != -1)
            {
                sql += " AND id != @id";
            }
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@name", name }, { "@id", id } };
            return SQLite.SQliteDataAccess.Query<int>(sql, parameters).FirstOrDefault() > 0;
         }
    }
}
