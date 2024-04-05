using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthenticationManager.Interfaces;
using AuthenticationManager.Models;
using UserManager.Models;
using UserManager.Helpers;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Messanger.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : Controller
    {
        private IConfiguration Configuration;
        private ITokenService tokenService;
        private IMemoryCache cache;

        public IdentityController(ITokenService service, IMemoryCache cache, IConfiguration configuration)
        {
            this.cache = cache;
            tokenService = service;
            Configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromForm]LoginModel model)
        {
            Dictionary<string, string> content = new Dictionary<string, string>()
            {
                {"Name", model.Name },
                {"Password", model.Password }
            };

            var response = await Sender.PostAsync(content, $"{Configuration["UserService"]}/api/user/login");



            if (response.IsSuccessStatusCode)
            {

                string responseMessage = await response.Content.ReadAsStringAsync();

                User user = JsonConvert.DeserializeObject<User>(responseMessage);

                TokenModel tokenModel = new TokenModel()
                {
                    Email = user.Email,
                    Name = user.Name,
                    Role = user.Role
                };

                string token = tokenService.CreateJwtToken(tokenModel);

                return Ok(token);
            }

            return BadRequest();
        }

    }
}
