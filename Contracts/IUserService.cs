using Communication.Attributes;
using Communication.Versioning;

namespace IdentityService.Contracts
{
    public interface IUserService
    {
        [Query]
        [ServiceVersion(1, ServiceVersionChange.Added)]
        Task<string> GetUser(string email);
    }
}
