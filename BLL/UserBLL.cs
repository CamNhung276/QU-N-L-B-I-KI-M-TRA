using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BLL
{
    public class UserBLL
    {
        private UserDAL userDAL = new UserDAL();

        public List<UserDTO> GetUsers()
        {
            return userDAL.GetUsers();
        }

        public bool AddUser(UserDTO user)
        {
            return userDAL.AddUser(user);
        }

        public bool UpdateUser(UserDTO user, string originalUsername)
        {
            return userDAL.UpdateUser(user, originalUsername);
        }

        public bool DeleteUser(string username)
        {
            return userDAL.DeleteUser(username);
        }

        // Phương thức thêm sinh viên
        public bool AddStudent(StudentDTO student)
        {
          
            return userDAL.AddStudent(student);
        }
        public bool UpdateStudent(StudentDTO student)
        {
            return userDAL.UpdateStudent(student); 
        }

        public UserDTO GetUserByUsername(string username)
        {
            return userDAL.GetUserByUsername(username);
        }

        public int GetUserIdByUsername(string username)
        {
            var user = userDAL.GetUsers().FirstOrDefault(u => u.Username == username);
            return user != null ? user.Id : 0;
        }
        public StudentDTO GetStudentByUserId(int userId)
        {
            return userDAL.GetStudentByUserId(userId);
        }
        public int GetUserCount()
        {
            return userDAL.GetUserCount();
        }

    }
}
