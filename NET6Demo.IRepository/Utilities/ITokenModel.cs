using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET6Demo.IRepository
{
    public interface ITokenModel
    {
        string Issuer { get; set; }
        string Audience { get; set; }
        double Expires { get; set; }
    }
}
