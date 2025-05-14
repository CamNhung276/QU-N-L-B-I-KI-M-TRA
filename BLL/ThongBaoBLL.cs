using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class ThongBaoBLL
    {
        private ThongBaoDAL thongBaoDAL;

        public ThongBaoBLL()
        {
            thongBaoDAL = new ThongBaoDAL();
        }

        // Kiểm tra kết nối
        public bool TestConnection()
        {
            return thongBaoDAL.TestConnection();
        }

        // Lấy tất cả thông báo
        public List<ThongBaoDTO> GetAllNotifications()
        {
            return thongBaoDAL.GetAllNotifications();
        }

        // Lấy thông báo cho người dùng cụ thể
        public List<ThongBaoDTO> LayThongBao(int userId, string role)
        {
            // Admin sẽ thấy tất cả thông báo
            if (role == "Admin" || role == "Teacher")
            {
                return thongBaoDAL.GetAllNotifications();
            }

            // Học sinh chỉ thấy thông báo chưa hết hạn
            return thongBaoDAL.GetNotificationsForUser(userId);
        }

        // Tạo thông báo mới
        public bool TaoThongBao(string title, string content, DateTime? expireDate, int createdById, string role)
        {
            if (role != "Admin" && role != "Teacher")
            {
                return false;
            }

            ThongBaoDTO notification = new ThongBaoDTO
            {
                Title = title,
                Content = content,
                CreatedDate = DateTime.Now,
                ExpireDate = expireDate,
                CreatedBy = createdById
            };

            int newId = thongBaoDAL.AddNotification(notification);
            return newId > 0;
        }

        // Xóa thông báo
        public bool XoaThongBao(int notificationId, string role)
        {
            // Chỉ Admin và Teacher mới có quyền xóa thông báo
            if (role != "Admin" && role != "Teacher")
            {
                return false;
            }

            return thongBaoDAL.DeleteNotification(notificationId);
        }

        // Đánh dấu thông báo đã đọc
        public bool DanhDauDaDoc(int notificationId, int userId)
        {
            return thongBaoDAL.MarkNotificationAsRead(notificationId, userId);
        }

        // Đếm số thông báo chưa đọc
        public int DemThongBaoChuaDoc(int userId)
        {
            return thongBaoDAL.CountUnreadNotifications(userId);
        }
    }
}