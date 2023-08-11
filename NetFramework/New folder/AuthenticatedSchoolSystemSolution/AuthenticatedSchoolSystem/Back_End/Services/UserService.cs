using AuthenticatedSchoolSystem.Back_End.Account;
using AuthenticatedSchoolSystem.Back_End.Repository;
using System.Threading.Tasks;

namespace AuthenticatedSchoolSystem.Back_End.Services
{
    public class UserService
    {
        private readonly UserRepository userRepository = new UserRepository();

        public Task<User> GetCurrentUser()
        {
            const int currentUserId = 10;
            return userRepository.GetUserById(currentUserId);
        }

        ////public Task<int> SendUserAMessage(User user, string message)
        ////{
        ////    return emailService.SendEmail(user.Email, message).ContinueWith(_ => 0);
        ////}
    }
}