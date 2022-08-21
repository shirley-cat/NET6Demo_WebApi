using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6Demo.IRepository
{
    public interface IUserInfo : IBaseViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? UserId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
