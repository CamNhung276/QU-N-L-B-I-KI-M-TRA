using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class CauHoiBLL
    {
        private CauHoiDAL dal = new CauHoiDAL();

        public List<CauHoiDTO> GetQuestionsByQuizId(int quizId)
        {
            return dal.GetQuestionsByQuizId(quizId);
        }
        public bool AddQuestion(CauHoiDTO question)
        {
            return dal.AddQuestion(question) > 0;
        }
        public void UpdateQuestion(CauHoiDTO question)
        {
            CauHoiDAL dal = new CauHoiDAL();
            dal.UpdateQuestion(question);
        }

        public bool DeleteQuestion(int questionId)
        {
            return dal.DeleteQuestion(questionId);
        }
        public int InsertAndGetId(CauHoiDTO cauHoi)
        {
            return dal.InsertAndGetId(cauHoi);
        }

        public void UpdateCorrectAnswerId(int questionId, int correctAnswerId)
        {
            dal.UpdateCorrectAnswerId(questionId, correctAnswerId);
        }
        public List<CauHoiDTO> LayCauHoiTheoDe(int maDeThi)
        {
            return dal.GetQuestionsByQuizId(maDeThi); 
        }
    }
}
