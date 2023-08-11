using _4.MyFirstApp.Models;

namespace _4.MyFirstApp.Services.Data
{
    public class SecurityDAO
    {
        internal bool FindByUser(UserModel user)
        {
            //if (user.Username == "Admin" && user.Password == "Admin")
            //{
            //    return true;
            //}

            //else
            //{
            //    return false;
            //}

            return user.Username == "Admin" && user.Password == "Admin";
        }
    }
}