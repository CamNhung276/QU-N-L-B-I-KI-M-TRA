using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class TestBLL
    {
        public List<TestDTO> GetQuizWithCategory(int userId)
        {
            return TestDAL.Instance.GetQuizWithCategory(userId); 
        }
        public bool AddTest(TestDTO test)
        {
            return TestDAL.Instance.AddTest(test);
            
        }
        public int GetCategoryIdByName(string categoryName)
        {
            return TestDAL.Instance.GetCategoryIdByName(categoryName);
        }
        public bool DeleteTest(int quizId)
        {
            return TestDAL.Instance.DeleteTest(quizId);
        }
        public bool UpdateTest(TestDTO test)
        {
            return TestDAL.Instance.UpdateTest(test);
        }



    }
}
