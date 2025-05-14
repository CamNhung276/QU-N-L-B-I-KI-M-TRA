using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class DocThongBaoBLL
    {
        private DocThongBaoDAL docThongBaoDAL;
        private int userId;

        public DocThongBaoBLL(int userId)
        {
            this.userId = userId;
            this.docThongBaoDAL = new DocThongBaoDAL();
        }

        public void DanhDauDaDoc(int notificationId)
        {
            docThongBaoDAL.DanhDauDaDoc(notificationId, userId);
        }
        public int DemThongBaoChuaDoc()
        {
            return docThongBaoDAL.DemThongBaoChuaDoc(userId);
        }
        public bool KiemTraDaDoc(int notificationId)
        {
            return docThongBaoDAL.KiemTraDaDoc(notificationId, userId);
        }
        public void CapNhatTrangThaiDoc(int notificationId, bool daDoc)
        {
            if (daDoc)
            {
                DanhDauDaDoc(notificationId);
            }
            else
            {
                docThongBaoDAL.HuyDanhDauDaDoc(notificationId, userId);
            }
        }
    }
} 