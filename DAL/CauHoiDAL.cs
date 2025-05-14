using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class CauHoiDAL : DataProvider
    {
        // Lấy danh sách câu hỏi theo QuizId
        public List<CauHoiDTO> GetQuestionsByQuizId(int quizId)
        {
            List<CauHoiDTO> questions = new List<CauHoiDTO>();
            string query = "SELECT Id, Text, CorrectAnswerId, QuizId FROM Question WHERE QuizId = @quizId";

            SqlParameter[] parameters = { new SqlParameter("@quizId", quizId) };
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                questions.Add(new CauHoiDTO
                {
                    Id = (int)row["Id"],
                    Text = row["Text"].ToString(),
                    CorrectAnswerId = row["CorrectAnswerId"] != DBNull.Value ? (int)row["CorrectAnswerId"] : -1,
                    QuizId = (int)row["QuizId"]
                });
            }

            return questions;
        }

        // Thêm câu hỏi
        public int AddQuestion(CauHoiDTO question)
        {
            string query = "INSERT INTO Question (Text, QuizId) OUTPUT INSERTED.Id VALUES (@text, @quizId)";
            SqlParameter[] parameters = {
                new SqlParameter("@text", question.Text),
                new SqlParameter("@quizId", question.QuizId)
            };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }
        public bool UpdateQuestion(CauHoiDTO question)
        {
            string query = "UPDATE Question SET Text = @text WHERE Id = @id";
            SqlParameter[] parameters = {
        new SqlParameter("@text", question.Text),
        new SqlParameter("@id", question.Id)
    };

            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteQuestion(int questionId)
        {
            string query = "DELETE FROM Question WHERE Id = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", questionId) };

            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
        public bool InsertQuestion(CauHoiDTO cauHoi)
        {
            string query = "INSERT INTO Question (Text, CorrectAnswerId, QuizId) VALUES (@Text, @CorrectAnswerId, @QuizId)";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Text", cauHoi.Text),
        new SqlParameter("@CorrectAnswerId", cauHoi.CorrectAnswerId),
        new SqlParameter("@QuizId", cauHoi.QuizId)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
        public int InsertAndGetId(CauHoiDTO cauHoi)
        {
            string query = "INSERT INTO Question (Text, QuizId) OUTPUT INSERTED.Id VALUES (@Text, @QuizId)";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Text", cauHoi.Text),
        new SqlParameter("@QuizId", cauHoi.QuizId)
            };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public void UpdateCorrectAnswerId(int questionId, int correctAnswerId)
        {
            string query = "UPDATE Question SET CorrectAnswerId = @correctAnswerId WHERE Id = @questionId";
            SqlParameter[] parameters = {
            new SqlParameter("@correctAnswerId", correctAnswerId),
            new SqlParameter("@questionId", questionId)
        };
            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }

    }

}
