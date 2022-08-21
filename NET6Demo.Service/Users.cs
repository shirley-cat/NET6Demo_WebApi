using NET6Demo.Interface.Dependency;
using NET6Demo.IRepository;
using NET6Demo.IService;
using Microsoft.Extensions.DependencyInjection;


namespace NET6Demo.Service
{
    public class Users : IUsers, IDependency
    {
        private readonly IServiceProvider _container;
        public Users(IServiceProvider container)
        {
            _container = container;
        }

        public void Dispose()
        {

        }

        public IUserInfo GetUser(string userId)
        {

            var user2 = _container.GetService<IUserInfo>();
            user2.Name = "catcat";
            user2.UserId = userId;
            user2.Id = 3;
            user2.CreateAt = DateTime.Now;
            return user2;
        }
    }
}
