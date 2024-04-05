using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationManager.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace AuthenticationManager.Models
{
    public class TokenService : ITokenService
    {
        public static readonly string Key = "$NotifyerProSuperSecretKeyForSafety$";
        public static readonly string _Audience = "My_App_Users";
        public static readonly string _Issuer = "Surmanidze_Denis_ft._Tyler_Durden";

        public string CreateJwtToken(TokenModel model)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, model.Name),
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(ClaimTypes.Role, model.Role)
            };

            ClaimsIdentity identity = 
                new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

            SigningCredentials credentials = new SigningCredentials
                (new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key)), SecurityAlgorithms.HmacSha256);

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateJwtSecurityToken
                (
                    subject: identity,
                    issuer: _Issuer,
                    audience: _Audience,
                    signingCredentials: credentials,
                    expires: DateTime.Now.AddMinutes(10)
                    
                );

            string tokenResult = tokenHandler.WriteToken(token);

            return tokenResult;

        }

        public bool ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var claims = tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = _Issuer,
                    ValidAudience = _Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key))

                }, out SecurityToken validator);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
