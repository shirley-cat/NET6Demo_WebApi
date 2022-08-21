using NET6Demo.IRepository;

namespace NET6Demo.IService
{
    public interface IUsers : IBaseService
    {
        IUserInfo GetUser(string userId);
    }
}
