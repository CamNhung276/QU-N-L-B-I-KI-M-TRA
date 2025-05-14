using System;
namespace DTO
{
    public class ThongBaoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int CreatedBy { get; set; }
        public string CreatorName { get; set; }
        public bool IsRead { get; set; }
    }
}