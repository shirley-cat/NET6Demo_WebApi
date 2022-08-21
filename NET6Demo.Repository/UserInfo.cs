using NET6Demo.Interface.Dependency;
using NET6Demo.IRepository;

namespace NET6Demo.Repository
{
    public class UserInfo : BaseViewModel, IUserInfo, IDependency
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
