using SampleAPI_Blazor.Models;

namespace SampleAPI_Blazor.Services
{
    public class AuthService
    {
        private List<User> Users { get; set; }

        public AuthService()
        {
            Users = new List<User>();
            Users.Add(new User
            {
                Id = 1,
                Email = "admin@mail.com",
                Password = "Test1234",
                IsAdmin = true,
                UserName = "Administrator"
            });

            Users.Add(new User
            {
                Id = 2,
                Email = "user@mail.com",
                Password = "Test1234",
                IsAdmin = false,
                UserName = "Sample User"
            });
        }

        public User? Login(string email, string password)
        {
            return Users.FirstOrDefault(x => x.Email == email && x.Password == password);   
        }
    }
}
