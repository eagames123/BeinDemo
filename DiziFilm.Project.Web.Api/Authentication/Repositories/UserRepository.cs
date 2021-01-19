using System.Collections.Generic;
using System.Linq;

namespace DiziFilm.Project.Web.Api.Authentication.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();

            users.Add(new User { Id = 1, Username = "bein", Password = "bein", Role = "test" });

            users.Add(new User { Id = 3, Username = "erkan", Password = "erkan", Role = "kontrol" });

            return users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password);
        }
    }
}
