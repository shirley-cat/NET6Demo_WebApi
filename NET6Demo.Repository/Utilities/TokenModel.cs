using NET6Demo.Interface.Dependency;
using NET6Demo.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6Demo.Repository
{
    public class TokenModel : ITokenModel, IDependency
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double Expires { get; set; }
    }
}
