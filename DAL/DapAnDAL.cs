using System.Collections.Generic;
using System.Data;
using System;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DapAnDAL : DataProvider
    {
        public List<DapAnDTO> GetAnswersByQuestionId(int questionId)
        {
            List<DapAnDTO> answers = new List<DapAnDTO>();
            string query = "SELECT Id, Text, QuestionId, IsCorrect FROM Answer WHERE QuestionId = @questionId";
            SqlParameter[] parameters = { new SqlParameter("@questionId", questionId) };
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                answers.Add(new DapAnDTO
                {
                    Id = (int)row["Id"],
                    Text = row["Text"].ToString(),
                    QuestionId = (int)row["QuestionId"],
                    IsCorrect = (bool)row["IsCorrect"]

                });
            }

            return answers;
        }

        public int AddAnswer(DapAnDTO answer)
        {
            string query = "INSERT INTO Answer (Text, QuestionId, IsCorrect) OUTPUT INSERTED.Id VALUES (@text, @questionId, @isCorrect)";
            SqlParameter[] parameters = {
        new SqlParameter("@text", answer.Text),
        new SqlParameter("@questionId", answer.QuestionId),
        new SqlParameter("@isCorrect", answer.IsCorrect)
    };
            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }



        public bool UpdateAnswer(DapAnDTO answer)
        {
            string query = "UPDATE Answer SET Text = @text WHERE Id = @id";
            SqlParameter[] parameters = {
                new SqlParameter("@text", answer.Text),
                new SqlParameter("@id", answer.Id)
            };
            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteAnswersByQuestionId(int questionId)
        {
            string query = "DELETE FROM Answer WHERE QuestionId = @questionId";
            SqlParameter[] parameters = { new SqlParameter("@questionId", questionId) };
            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }
        public int InsertAnswer(string text, int questionId, bool isCorrect)
        {
            string query = "INSERT INTO Answer (Text, QuestionId, IsCorrect) OUTPUT INSERTED.Id VALUES (@text, @questionId, @isCorrect)";
            SqlParameter[] parameters = {
        new SqlParameter("@text", text),
        new SqlParameter("@questionId", questionId),
        new SqlParameter("@isCorrect", isCorrect)
    };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1;
        }
        public int InsertAndGetId(DapAnDTO answer)
        {
            string query = "INSERT INTO Answer (Text, QuestionId, IsCorrect) OUTPUT INSERTED.Id VALUES (@Text, @QuestionId, @IsCorrect)";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Text", answer.Text),
        new SqlParameter("@QuestionId", answer.QuestionId),
        new SqlParameter("@IsCorrect", answer.IsCorrect)
            };

            object result = DataProvider.Instance.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

    }
}
