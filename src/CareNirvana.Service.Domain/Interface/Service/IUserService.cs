using CareNirvana.Service.Domain.Model;

namespace CareNirvana.Service.Domain.Interface
{
    public interface IUserService
    {
        SecurityUser Authenticate(string username, string password);
    }
}
