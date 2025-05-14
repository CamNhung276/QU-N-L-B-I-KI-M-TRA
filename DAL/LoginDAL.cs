using System.Data;
using System.Data.SqlClient;
using System;
using DTO;
namespace DAL
{
    public class LoginDAL : DataProvider
    {
        public bool CheckLogin(LoginDTO login, out string role, out int userId)
        {
            role = string.Empty;
            userId = 0;
            // Thêm COLLATE SQL_Latin1_General_CP1_CS_AS để phân biệt hoa thường cho Username
            string query = "SELECT Role, Id FROM [User] WHERE Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS AND Password = @Password";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", login.Username),
                new SqlParameter("@Password", login.Password)
            };
            // Thực hiện truy vấn
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                role = row["Role"].ToString();
                userId = Convert.ToInt32(row["Id"]);
                return true;
            }
            return false;
        }

        // Lấy thông tin người dùng theo tên đăng nhập và mật khẩu
        public UserDTO GetUserByUsernameAndPassword(string username, string password)
        {
            // Thêm COLLATE SQL_Latin1_General_CP1_CS_AS để phân biệt hoa thường cho Username
            string query = "SELECT Id, Username, Password, Role, Name FROM [User] WHERE Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS AND Password = @Password";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                int userId = row["Id"] != DBNull.Value ? (int)row["Id"] : 0;
                return new UserDTO
                {
                    Id = userId,
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Role = row["Role"].ToString(),
                    Name = row["Name"].ToString()
                };
            }
            return null;
        }
    }
}