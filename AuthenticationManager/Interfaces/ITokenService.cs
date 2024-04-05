using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationManager.Models;

namespace AuthenticationManager.Interfaces
{
    public interface ITokenService
    {
        public string CreateJwtToken(TokenModel model);

        public bool ValidateJwtToken(string token);
    }
}
