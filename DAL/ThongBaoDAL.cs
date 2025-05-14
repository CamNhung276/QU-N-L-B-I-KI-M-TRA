using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ThongBaoDAL : DataProvider
    {

        public List<ThongBaoDTO> GetAllNotifications()
        {
            try
            {
                string query = @"SELECT n.[Id], n.[Title], n.[Content], n.[CreatedDate], 
                                 n.[ExpireDate], n.[CreatedBy], u.Name as CreatorName
                                 FROM [Notifications] n
                                 LEFT JOIN [User] u ON n.[CreatedBy] = u.[Id]
                                 ORDER BY n.[CreatedDate] DESC";

                DataTable dt = ExecuteQuery(query);
                return ConvertToNotificationList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy danh sách thông báo: " + ex.Message);
                return new List<ThongBaoDTO>();
            }
        }

        // Lấy thông báo cho người dùng cụ thể (Student)
        public List<ThongBaoDTO> GetNotificationsForUser(int userId)
        {
            try
            {
                string query = @"SELECT n.[Id], n.[Title], n.[Content], n.[CreatedDate], 
                                 n.[ExpireDate], n.[CreatedBy], u.Name as CreatorName,
                                 CASE WHEN nr.UserId IS NOT NULL THEN 1 ELSE 0 END AS IsRead
                                 FROM [Notifications] n
                                 LEFT JOIN [User] u ON n.[CreatedBy] = u.[Id]
                                 LEFT JOIN [NotificationReads] nr ON n.[Id] = nr.[NotificationId] AND nr.[UserId] = @UserId
                                 WHERE (n.[ExpireDate] IS NULL OR n.[ExpireDate] > GETDATE())
                                 ORDER BY n.[CreatedDate] DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int) { Value = userId }
                };

                DataTable dt = ExecuteQuery(query, parameters);
                return ConvertToNotificationList(dt, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy danh sách thông báo cho người dùng: " + ex.Message);
                return new List<ThongBaoDTO>();
            }
        }

        // Thêm thông báo mới
        public int AddNotification(ThongBaoDTO notification)
        {
            try
            {
                string query = @"INSERT INTO [Notifications] ([Title], [Content], [CreatedDate], [ExpireDate], [CreatedBy])
                               VALUES (@Title, @Content, @CreatedDate, @ExpireDate, @CreatedBy);
                               SELECT SCOPE_IDENTITY();";

                SqlParameter[] parameters = {
                    new SqlParameter("@Title", SqlDbType.NVarChar) { Value = notification.Title },
                    new SqlParameter("@Content", SqlDbType.NVarChar) { Value = notification.Content },
                    new SqlParameter("@CreatedDate", SqlDbType.DateTime) { Value = notification.CreatedDate },
                    new SqlParameter("@ExpireDate", SqlDbType.DateTime) {
                        Value = notification.ExpireDate.HasValue ? (object)notification.ExpireDate : DBNull.Value
                    },
                    new SqlParameter("@CreatedBy", SqlDbType.Int) { Value = notification.CreatedBy }
                };

                object result = ExecuteScalar(query, parameters);
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm thông báo: " + ex.Message);
                return 0;
            }
        }

        // Xóa thông báo
        public bool DeleteNotification(int notificationId)
        {
            try
            {
                // Xóa các bản ghi đọc liên quan trước
                string deleteReadsQuery = "DELETE FROM [NotificationReads] WHERE [NotificationId] = @NotificationId";
                SqlParameter[] deleteReadsParams = {
                    new SqlParameter("@NotificationId", SqlDbType.Int) { Value = notificationId }
                };
                ExecuteNonQuery(deleteReadsQuery, deleteReadsParams);

                // Sau đó xóa thông báo
                string deleteNotificationQuery = "DELETE FROM [Notifications] WHERE [Id] = @NotificationId";
                SqlParameter[] deleteNotificationParams = {
                    new SqlParameter("@NotificationId", SqlDbType.Int) { Value = notificationId }
                };
                int rowsAffected = ExecuteNonQuery(deleteNotificationQuery, deleteNotificationParams);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa thông báo: " + ex.Message);
                return false;
            }
        }

        // Đánh dấu thông báo đã đọc
        public bool MarkNotificationAsRead(int notificationId, int userId)
        {
            try
            {
                // Kiểm tra xem đã đọc chưa
                string checkQuery = "SELECT COUNT(*) FROM [NotificationReads] WHERE [NotificationId] = @NotificationId AND [UserId] = @UserId";
                SqlParameter[] checkParams = {
                    new SqlParameter("@NotificationId", SqlDbType.Int) { Value = notificationId },
                    new SqlParameter("@UserId", SqlDbType.Int) { Value = userId }
                };

                int count = Convert.ToInt32(ExecuteScalar(checkQuery, checkParams));
                if (count > 0)
                    return true; // Đã đọc rồi

                // Thêm bản ghi đánh dấu đã đọc
                string insertQuery = @"INSERT INTO [NotificationReads] ([NotificationId], [UserId], [ReadDate])
                                     VALUES (@NotificationId, @UserId, @ReadDate)";
                SqlParameter[] insertParams = {
                    new SqlParameter("@NotificationId", SqlDbType.Int) { Value = notificationId },
                    new SqlParameter("@UserId", SqlDbType.Int) { Value = userId },
                    new SqlParameter("@ReadDate", SqlDbType.DateTime) { Value = DateTime.Now }
                };

                int rowsAffected = ExecuteNonQuery(insertQuery, insertParams);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi đánh dấu đã đọc: " + ex.Message);
                return false;
            }
        }

        // Đếm số thông báo chưa đọc
        public int CountUnreadNotifications(int userId)
        {
            try
            {
                string query = @"SELECT COUNT(*) 
                               FROM [Notifications] n
                               LEFT JOIN [NotificationReads] nr ON n.[Id] = nr.[NotificationId] AND nr.[UserId] = @UserId
                               WHERE (n.[ExpireDate] IS NULL OR n.[ExpireDate] > GETDATE())
                               AND nr.[UserId] IS NULL";

                SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int) { Value = userId }
                };

                object result = ExecuteScalar(query, parameters);
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi đếm thông báo chưa đọc: " + ex.Message);
                return 0;
            }
        }
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    return conn.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }
        // Hàm hỗ trợ chuyển đổi DataTable thành List<ThongBaoDTO>
        private List<ThongBaoDTO> ConvertToNotificationList(DataTable dt, bool includeReadStatus = false)
        {
            List<ThongBaoDTO> notificationList = new List<ThongBaoDTO>();

            foreach (DataRow row in dt.Rows)
            {
                ThongBaoDTO notification = new ThongBaoDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Title = row["Title"].ToString(),
                    Content = row["Content"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    ExpireDate = row["ExpireDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(row["ExpireDate"]),
                    CreatedBy = Convert.ToInt32(row["CreatedBy"]),
                    CreatorName = row["CreatorName"]?.ToString() ?? "Unknown"
                };

                if (includeReadStatus && dt.Columns.Contains("IsRead"))
                {
                    notification.IsRead = Convert.ToBoolean(row["IsRead"]);
                }

                notificationList.Add(notification);
            }

            return notificationList;
        }
    }
}