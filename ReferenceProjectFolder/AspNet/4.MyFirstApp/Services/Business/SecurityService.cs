using _4.MyFirstApp.Models;
using _4.MyFirstApp.Services.Data;

namespace _4.MyFirstApp.Services.Business
{
    public class SecurityService
    {
        private readonly SecurityDAO daoService = new SecurityDAO();

        public bool Authenticate(UserModel user)
        {
            return daoService.FindByUser(user);
        }
    }
}