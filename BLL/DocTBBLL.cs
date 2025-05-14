using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class DocTBBLL
    {
        private ThongBaoBLL thongBaoBLL;
        private int userId;

        public DocTBBLL(int userId)
        {
            this.userId = userId;
            this.thongBaoBLL = new ThongBaoBLL();
        }

        public void DanhDauDaDoc(int notificationId)
        {
            thongBaoBLL.DanhDauDaDoc(notificationId, userId);
        }

        public int DemThongBaoChuaDoc()
        {
            return thongBaoBLL.DemThongBaoChuaDoc(userId);
        }

        public List<ThongBaoDTO> LayThongBao()
        {
            return thongBaoBLL.LayThongBao(userId, "Student");
        }

        public void CapNhatTrangThaiDoc(int notificationId, bool daDoc)
        {
            if (daDoc)
            {
                DanhDauDaDoc(notificationId);
            }
        }
    }
}
