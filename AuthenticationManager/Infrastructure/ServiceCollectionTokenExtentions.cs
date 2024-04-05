using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AuthenticationManager.Interfaces;
using AuthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationManager.Infrastructure
{
    public static class ServiceCollectionTokenExtentions
    {
        public static void AddJwtTokenService(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
        }

        public static void AddJwtBearerAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options=> 
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = TokenService._Issuer,
                    ValidAudience = TokenService._Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenService.Key))
                };
            });
        }
    }
}
