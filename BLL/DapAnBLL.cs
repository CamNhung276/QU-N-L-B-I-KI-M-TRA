using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class DapAnBLL
    {
        private DapAnDAL dapAnDal = new DapAnDAL();

        public List<DapAnDTO> GetAnswersByQuestionId(int questionId)
        {
            return dapAnDal.GetAnswersByQuestionId(questionId);
        }

        public bool AddAnswer(DapAnDTO answer)
        {
            return dapAnDal.AddAnswer(answer) > 0;
        }

        public bool UpdateAnswer(DapAnDTO answer)
        {
            return dapAnDal.UpdateAnswer(answer);
        }

        public void DeleteAnswersByQuestionId(int questionId)
        {
            DapAnDAL dal = new DapAnDAL();
            dal.DeleteAnswersByQuestionId(questionId);
        }

        public int InsertAnswer(string text, int questionId, bool isCorrect)
        {
            var answer = new DapAnDTO
            {
                Text = text,
                QuestionId = questionId,
                IsCorrect = isCorrect
            };

            int insertedId = dapAnDal.InsertAndGetId(answer);

            if (insertedId > 0 && isCorrect)
            {
                var cauHoiBll = new CauHoiBLL();
                cauHoiBll.UpdateCorrectAnswerId(questionId, insertedId);
            }

            return insertedId;
        }



    }
}
