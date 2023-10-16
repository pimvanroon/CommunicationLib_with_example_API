using IdentityService.Contracts;

namespace IdentityService.Services
{
    public class UserService : IUserService
    {
        public Task<string> GetUser(string email)

        {
            if (email == "test@test.nl")
            {
                return Task.FromResult("User found");
            }
            else
            {
                return Task.FromResult("User not found");
            }
        }
    }
}
