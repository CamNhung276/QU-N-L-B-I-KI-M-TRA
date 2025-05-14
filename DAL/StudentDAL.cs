using System.Data.SqlClient;
using System;
using DTO;

namespace DAL
{
    public class StudentDAL : DataProvider
    {
        public bool AddStudent(StudentDTO student)
        {
            string query = "INSERT INTO Student (Name, Email, UserId) VALUES (@Name, @Email, @UserId)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", student.Name),
                new SqlParameter("@Email", student.Email),
                new SqlParameter("@UserId", student.UserId)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }
        // Trong StudentDAL
        public int LayStudentIdTheoUserId(int userId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT Id FROM Student WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }


    }
}
