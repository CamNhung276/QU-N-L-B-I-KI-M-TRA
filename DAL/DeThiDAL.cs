using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DeThiDAL : DataProvider
    {
        public DataTable LayTatCaDe()
        {
            string query = "SELECT Id, Title, TimeToBeWorked FROM Quiz";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public List<DeThiDTO> ChuyenSangDanhSachDeThi(DataTable dt)
        {
            List<DeThiDTO> danhSach = new List<DeThiDTO>();

            foreach (DataRow row in dt.Rows)
            {
                DeThiDTO de = new DeThiDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TenDeThi = row["Title"].ToString(),
                    ThoiGianLamBai = row["TimeToBeWorked"] != DBNull.Value ? Convert.ToInt32(row["TimeToBeWorked"]) : 0
                };

                danhSach.Add(de);
            }

            return danhSach;
        }

        public DataTable LayCauHoiTheoDeThi(int quizId)
        {
            string query = "SELECT Id, Text, CorrectAnswerId FROM Question WHERE QuizId = @quizId";
            SqlParameter[] parameters = {
                new SqlParameter("@quizId", quizId)
            };
            return DataProvider.Instance.ExecuteQuery(query, parameters);
        }

        public DataTable LayDapAnTheoCauHoi(int questionId)
        {
            string query = "SELECT Id, Text, IsCorrect FROM Answer WHERE QuestionId = @questionId";
            SqlParameter[] parameters = {
                new SqlParameter("@questionId", questionId)
            };
            return DataProvider.Instance.ExecuteQuery(query, parameters);
        }
        public DataRow LayDeThiTheoId(int id)
        {
            string query = "SELECT Id, Title, TimeToBeWorked FROM Quiz WHERE Id = @id";
            SqlParameter[] parameters = {
        new SqlParameter("@id", id)
    };

            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]; // Trả về DataRow của đề thi có Id = id
            }

            return null; // Nếu không tìm thấy, trả về null
        }


        public void UpdateThoiGianLamBai(DeThiDTO deThi)
        {
            string query = "UPDATE Quiz SET TimeToBeWorked = @time WHERE Id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@time", deThi.ThoiGianLamBai),
                new SqlParameter("@id", deThi.Id)
            };

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
