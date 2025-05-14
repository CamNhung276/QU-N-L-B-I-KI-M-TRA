using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.SqlServer.Server;
using System.Security.Policy;
using System.Data.SqlClient;

using DAL;
using DTO;

namespace DAL
{
    public class MonHocDAL : DataProvider
    {
        public List<MonHocDTO> GetCategories()
        {
            string query = "SELECT * FROM Category ";
            DataTable dt = ExecuteQuery(query);

            List<MonHocDTO> categories = new List<MonHocDTO>();
            foreach (DataRow row in dt.Rows)
            {
                categories.Add(new MonHocDTO(Convert.ToInt32(row["Id"]), row["Name"].ToString()));
            }

            return categories;
        }
        public bool AddCategory(MonHocDTO category)
        {
            string query = "INSERT INTO Category (Name) VALUES (@Name)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", category.Name)
            };
            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateCategory(MonHocDTO category)
        {
            string query = "UPDATE Category SET Name = @Name WHERE Id = @Id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Name", category.Name),
                new SqlParameter("@Id", category.Id)
            };
            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteCategory(int id)
        {
            string query = "DELETE FROM Category WHERE Id = @Id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", id)
            };
            return ExecuteNonQuery(query, parameters) > 0;
        }

    }

}
