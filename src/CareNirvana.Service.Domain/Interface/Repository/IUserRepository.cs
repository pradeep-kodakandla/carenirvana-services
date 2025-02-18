using CareNirvana.Service.Domain.Model;

namespace CareNirvana.Service.Domain.Interface
{
    public interface IUserRepository
    {
        bool ValidateUser(string userName, string password);
        SecurityUser? GetUser(string username, string password);
    }
}
