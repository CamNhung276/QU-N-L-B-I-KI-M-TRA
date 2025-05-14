using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class MonHocBLL
    {

        private MonHocDAL monhocDAL = new MonHocDAL();

        public List<MonHocDTO> GetCategories()
        {
            return monhocDAL.GetCategories();
        }

        public bool AddCategory(MonHocDTO category)
        {
            return monhocDAL.AddCategory(category);
        }

        public bool UpdateCategory(MonHocDTO category)
        {
            return monhocDAL.UpdateCategory(category);
        }

        public bool DeleteCategory(int id)
        {
            return monhocDAL.DeleteCategory(id);
        }
        public int GetCategoryCount()
        {
            return monhocDAL.GetCategories().Count;
        }

    }
}
