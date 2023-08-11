//using SchoolSystem.Models;
//using SchoolSystem.Repository;
//using System.Threading.Tasks;

//namespace SchoolSystem.Services
//{
//    public class UserService
//    {
//        readonly UserRepository userRepository = new UserRepository();
//        readonly EmailService emailService = new EmailService();

//        public Task<User> GetCurrentUser()
//        {
//            const int currentUserId = 10;
//            return userRepository.GetUserById(currentUserId);
//        }

//        public Task<int> SendUserAMessage(User user, string message)
//        {
//            return emailService.SendEmail(user.Email, message).ContinueWith(_ => 0);
//        }
//    }
//}