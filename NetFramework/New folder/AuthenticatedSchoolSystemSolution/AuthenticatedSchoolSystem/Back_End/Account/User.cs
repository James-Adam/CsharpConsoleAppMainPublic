using System.ComponentModel.DataAnnotations;

namespace AuthenticatedSchoolSystem.Back_End.Account
{
    public class User
    {
        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        [Key] public int Id { get; private set; }

        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}