using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class KetQuaDAL : DataProvider
    {
        // Phương thức lưu kết quả
        public bool LuuKetQua(KetQuaDTO mark)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "INSERT INTO Mark (StudentId, QuizId, Score, DateTaken) VALUES (@StudentId, @QuizId, @Score, @DateTaken)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentId", mark.StudentId);
                cmd.Parameters.AddWithValue("@QuizId", mark.QuizId);
                cmd.Parameters.AddWithValue("@Score", mark.Score);
                cmd.Parameters.AddWithValue("@DateTaken", mark.DateTaken);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Phương thức lấy tất cả kết quả
        public List<KetQuaDTO> LayTatCaKetQua()
        {
            List<KetQuaDTO> list = new List<KetQuaDTO>();
            using (SqlConnection conn = GetConnection())
            {
                string query = @"SELECT m.StudentId, m.QuizId, m.Score, m.DateTaken, 
                               s.Name as StudentName, q.Title as QuizTitle 
                               FROM Mark m
                               INNER JOIN Student s ON m.StudentId = s.Id
                               INNER JOIN Quiz q ON m.QuizId = q.Id";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KetQuaDTO dto = new KetQuaDTO
                    {
                        StudentId = (int)reader["StudentId"],
                        QuizId = (int)reader["QuizId"],
                        Score = (decimal)reader["Score"],
                        DateTaken = (DateTime)reader["DateTaken"],
                        StudentName = reader["StudentName"].ToString(),
                        QuizTitle = reader["QuizTitle"].ToString()
                    };
                    list.Add(dto);
                }
                reader.Close();
            }
            return list;
        }

        // Phương thức đếm tất cả kết quả
        public int DemTatCaKetQua()
        {
            int count = 0;
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Mark";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }

        // Phương thức lấy tất cả điểm
        public List<decimal> LayTatCaDiem()
        {
            List<decimal> list = new List<decimal>();

            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT Score FROM Mark";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add((decimal)reader["Score"]);
                }

                reader.Close();
            }

            return list;
        }
        // Phương thức lấy kết quả theo học sinh (user)
        public List<KetQuaDTO> LayKetQuaTheoUser(int userId)
        {
            List<KetQuaDTO> list = new List<KetQuaDTO>();
            using (SqlConnection conn = GetConnection())
            {
                string query = @"SELECT m.StudentId, m.QuizId, m.Score, m.DateTaken,
                               s.Name as StudentName, q.Title as QuizTitle
                        FROM Mark m
                        INNER JOIN Student s ON m.StudentId = s.Id
                        INNER JOIN Quiz q ON m.QuizId = q.Id
                        WHERE m.StudentId = @UserId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KetQuaDTO dto = new KetQuaDTO
                    {
                        StudentId = (int)reader["StudentId"],
                        QuizId = (int)reader["QuizId"],
                        Score = (decimal)reader["Score"],
                        DateTaken = (DateTime)reader["DateTaken"],
                        StudentName = reader["StudentName"].ToString(),
                        QuizTitle = reader["QuizTitle"].ToString()
                    };
                    list.Add(dto);
                }
                reader.Close();
            }
            return list;
        }

    }
}
