using System;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DocThongBaoDAL : DataProvider
    {
        public bool DanhDauDaDoc(int notificationId, int userId)
        {
            try
            {
                string query = @"IF NOT EXISTS (SELECT 1 FROM [NotificationReads] 
                                             WHERE [NotificationId] = @NotificationId AND [UserId] = @UserId)
                                BEGIN
                                    INSERT INTO [NotificationReads] ([NotificationId], [UserId], [ReadDate])
                                    VALUES (@NotificationId, @UserId, @ReadDate)
                                END";

                SqlParameter[] parameters = {
                    new SqlParameter("@NotificationId", SqlDbType.Int) { Value = notificationId },
                    new SqlParameter("@UserId", SqlDbType.Int) { Value = userId },
                    new SqlParameter("@ReadDate", SqlDbType.DateTime) { Value = DateTime.Now }
                };

                int rowsAffected = ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi đánh dấu đã đọc: " + ex.Message);
                return false;
            }
        }

        public int DemThongBaoChuaDoc(int userId)
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

        public bool KiemTraDaDoc(int notificationId, int userId)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM [NotificationReads] WHERE [NotificationId] = @NotificationId AND [UserId] = @UserId";
                SqlParameter[] parameters = {
                    new SqlParameter("@NotificationId", SqlDbType.Int) { Value = notificationId },
                    new SqlParameter("@UserId", SqlDbType.Int) { Value = userId }
                };

                int count = Convert.ToInt32(ExecuteScalar(query, parameters));
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kiểm tra đã đọc: " + ex.Message);
                return false;
            }
        }
        public bool HuyDanhDauDaDoc(int notificationId, int userId)
        {
            try
            {
                string query = "DELETE FROM [NotificationReads] WHERE [NotificationId] = @NotificationId AND [UserId] = @UserId";

                SqlParameter[] parameters = {
            new SqlParameter("@NotificationId", SqlDbType.Int) { Value = notificationId },
            new SqlParameter("@UserId", SqlDbType.Int) { Value = userId }
        };

                int rowsAffected = ExecuteNonQuery(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi hủy đánh dấu đã đọc: " + ex.Message);
                return false;
            }
        }

    }
}