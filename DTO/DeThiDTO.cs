using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DeThiDTO
    {
        public int Id { get; set; }
        public string TenDeThi { get; set; } 
        public int ThoiGianLamBai { get; set; } 

        public DeThiDTO() { }

        public DeThiDTO(int id, string tenDeThi, int thoiGianLamBai)
        {
            Id = id;
            TenDeThi = tenDeThi;
            ThoiGianLamBai = thoiGianLamBai;
        }


    }
}
