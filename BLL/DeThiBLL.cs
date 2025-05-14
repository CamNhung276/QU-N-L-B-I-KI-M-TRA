using System;
using System.Collections.Generic;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class DeThiBLL
    {
        private DeThiDAL dal = new DeThiDAL();

        public List<DeThiDTO> LayTatCaDe()
        {
            var dt = dal.LayTatCaDe();
            return ConvertDataTableToList(dt);
        }

        private List<DeThiDTO> ConvertDataTableToList(DataTable dt)
        {
            List<DeThiDTO> listDeThi = new List<DeThiDTO>();

            foreach (DataRow row in dt.Rows)
            {
                var deThi = new DeThiDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TenDeThi = row["Title"].ToString(),
                    ThoiGianLamBai = row["TimeToBeWorked"] != DBNull.Value ? Convert.ToInt32(row["TimeToBeWorked"]) : 0
                };
                listDeThi.Add(deThi);
            }

            return listDeThi;
        }
        public DeThiDTO LayDeThiTheoId(int id)
        {
            DataRow row = dal.LayDeThiTheoId(id);
            if (row != null)
            {
                return new DeThiDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TenDeThi = row["Title"].ToString(),
                    ThoiGianLamBai = row["TimeToBeWorked"] != DBNull.Value ? Convert.ToInt32(row["TimeToBeWorked"]) : 0
                };
            }

            return null;
        }

        public void UpdateThoiGianLamBai(DeThiDTO deThi)
        {
            dal.UpdateThoiGianLamBai(deThi);
        }
       

    }
}
