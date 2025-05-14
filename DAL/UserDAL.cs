using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;
using DTO;

namespace DAL
{
    public class UserDAL : DataProvider
    {
        public List<UserDTO> GetUsers()
        {
            List<UserDTO> users = new List<UserDTO>();
            string query = "SELECT Username, Password, Role, Name FROM [User]"; 

            DataTable dt = ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                users.Add(new UserDTO
                {
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(), 
                    Role = row["Role"].ToString(),
                    Name = row["Name"].ToString()          
                });
            }

            return users;
        }
        public bool AddStudent(StudentDTO student)
        {
            string query = "INSERT INTO Student (Name, Email, UserId) VALUES (@Name, @Email, @UserId)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", student.Name),
                new SqlParameter("@Email", student.Email),
                new SqlParameter("@UserId", student.UserId) // Lấy ID người dùng đã được tạo
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }
        public UserDTO GetUserByUsername(string username)
        {
            string query = "SELECT Id, Username, Password, Role, Name FROM [User] WHERE Username COLLATE Latin1_General_CS_AS = @Username";


            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Username", username)
            };

            DataTable dt = ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new UserDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Role = row["Role"].ToString(),
                    Name = row["Name"].ToString()
                };
            }

            return null;
        }

        public bool UpdateStudent(StudentDTO student)
        {
            string query = "UPDATE Student SET Name = @Name, Email = @Email WHERE UserId = @UserId";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Name", student.Name),
        new SqlParameter("@Email", student.Email),
        new SqlParameter("@UserId", student.UserId)
            };
            return ExecuteNonQuery(query, parameters) > 0;
        }
        public bool AddUser(UserDTO user)
        {
            string query = "INSERT INTO [User] (Username, Password, Role, Name) VALUES (@Username, @Password, @Role, @Name)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Role", user.Role),
                new SqlParameter("@Name", user.Name ?? string.Empty)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }
        public bool UpdateUser(UserDTO user, string originalUsername)
        {
            string query = "UPDATE [User] SET Username = @NewUsername, Password = @Password, Role = @Role, Name = @Name WHERE Username = @OldUsername";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@NewUsername", user.Username),
        new SqlParameter("@Password", user.Password),
        new SqlParameter("@Role", user.Role),
        new SqlParameter("@Name", user.Name),
        new SqlParameter("@OldUsername", originalUsername)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }


        // Xóa người dùng
        public bool DeleteUser(string username)
        {
            
            string query = "DELETE FROM [User] WHERE Username = @Username";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Username", username)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }
        // Trong UserDAL.cs
        public StudentDTO GetStudentByUserId(int userId)
        {
            string query = "SELECT Id, Name, Email, UserId FROM Student WHERE UserId = @UserId";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@UserId", userId)
            };

            DataTable dt = ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new StudentDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Email = row["Email"].ToString(),
                    UserId = Convert.ToInt32(row["UserId"])
                };
            }

            return null;
        }
        public int GetUserCount()
        {
            string query = "SELECT COUNT(*) FROM [User]";
            object result = ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

    }
}
