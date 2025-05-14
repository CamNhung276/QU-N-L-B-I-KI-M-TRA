using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
   public class StudentBLL
    {
        private StudentDAL studentDal = new StudentDAL();
        public int LayStudentIdTheoUserId(int userId)
        {
            return studentDal.LayStudentIdTheoUserId(userId);
        }
       
    }
}
