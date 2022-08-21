using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCode.JWT
{
    internal class JwtModel: IJwtModel
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double Expires { get; set; }
    }
}
