using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class KetQuaBLL
    {
        private KetQuaDAL dal = new KetQuaDAL();
        public bool LuuKetQua(KetQuaDTO mark)
        {
            return dal.LuuKetQua(mark);
        }
        public List<KetQuaDTO> LayKetQuaTheoUser(int userId)
        {
            return dal.LayKetQuaTheoUser(userId);
        }

        // Phương thức lấy tất cả kết quả
        public List<KetQuaDTO> LayTatCaKetQua()
        {
            return dal.LayTatCaKetQua();
        }
        public int DemTatCaKetQua()
        {
            return dal.DemTatCaKetQua();
        }
        public List<decimal> LayTatCaDiem()
        {
            return dal.LayTatCaDiem();
        }
        public int DemSoKetQua()
        {
            return dal.DemTatCaKetQua(); 
        }
    }
}
