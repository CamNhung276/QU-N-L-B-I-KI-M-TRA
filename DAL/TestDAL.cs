using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class TestDAL : DataProvider
    {
        private static TestDAL instance;

        public new static TestDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TestDAL();
                return instance;
            }
        }

        public List<TestDTO> GetQuizWithCategory(int userId)
        {
            List<TestDTO> list = new List<TestDTO>();
            string query = @"
                SELECT q.Id AS QuizId, q.Title AS QuizTitle, c.Name AS CategoryName
                FROM Quiz q
                JOIN Category c ON q.CategoryId = c.Id
                WHERE q.CreatedByUserId = @userId";

            SqlParameter[] parameters = {
                new SqlParameter("@userId", userId)
            };

            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new TestDTO
                {
                    QuizId = Convert.ToInt32(row["QuizId"]),
                    QuizTitle = row["QuizTitle"].ToString(),
                    CategoryName = row["CategoryName"].ToString()
                });
            }

            return list;
        }

        public bool AddTest(TestDTO test)
        {
            string query = "INSERT INTO Quiz (Title, CategoryId, CreatedByUserId) VALUES (@title, @categoryId, @createdByUserId)";
            SqlParameter[] parameters = {
                new SqlParameter("@title", test.QuizTitle),
                new SqlParameter("@categoryId", test.CategoryId),
                new SqlParameter("@createdByUserId", test.CreatedByUserId)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public int GetCategoryIdByName(string categoryName)
        {
            string query = "SELECT Id FROM Category WHERE Name = @name";
            SqlParameter[] parameters = {
                new SqlParameter("@name", categoryName)
            };

            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["Id"]);
            }

            return -1; // Nếu không tìm thấy, trả về -1
        }

        public bool DeleteTest(int quizId)
        {
            string query = "DELETE FROM Quiz WHERE Id = @id";
            SqlParameter[] parameters = {
                new SqlParameter("@id", quizId)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateTest(TestDTO test)
        {
            string query = "UPDATE Quiz SET Title = @title, CategoryId = @categoryId WHERE Id = @id";
            SqlParameter[] parameters = {
                new SqlParameter("@title", test.QuizTitle),
                new SqlParameter("@categoryId", test.CategoryId),
                new SqlParameter("@id", test.QuizId)
            };

            return DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0;
        }

    }
}
