using DAL;
using DTO;

namespace BLL
{
    public class LoginBLL
    {
        private LoginDAL loginDAL = new LoginDAL();
        public bool AuthenticateUser(LoginDTO login, out string role, out int userId)
        {
            return loginDAL.CheckLogin(login, out role, out userId);
        }

        public UserDTO GetUserInfo(LoginDTO login)
        {
            return loginDAL.GetUserByUsernameAndPassword(login.Username, login.Password);
        }

        public UserDTO GetUserByUsername(string username)
        {
            UserDAL userDAL = new UserDAL();
            return userDAL.GetUserByUsername(username);
        }
    }
}
