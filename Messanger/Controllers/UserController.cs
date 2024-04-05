using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManager.Models;
using UserManager.Helpers;
using Messanger.Models;
using Messanger.Interfaces;
using AuthenticationManager.Models;
using AuthenticationManager.Interfaces;

namespace Messanger.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        public UserController(IUserRepository repository, ITokenService tokenService)
        {
            this.tokenService = tokenService;
            this.repository = repository;
        }

        private ITokenService tokenService;
        private IUserRepository repository;

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            List<User> users = await repository.GetUsersAsync();

            if (users.Count() == 0)
            {
                return Ok(new {Name = "poshel v pizdy" });
            }

            return Ok(users);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserAsync([FromForm]User user)
        {
            

            if (user != null)
            {
                
                await repository.CreateUserAsync(user);

                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUserAsync([FromForm]UpdateUserModel user)
        {
            if (user != null)
            {
                await repository.UpdateUserAsync(user);

                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("remove/{id}")]
        public async Task RemoveUserAsync(long id)
        {
            await repository.DeleteUserAsync(id);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(long id)
        {
            try
            {
                User user = await repository.GetUserByIdAsync(id);

                Console.WriteLine(user.Email+"users email");

                return Ok(user);
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpGet("get/mess/{email}")]
        public async Task<IActionResult> GetUserByEmailAsync(string email)
        {
            try
            {
                User user = await repository.GetUserByEmailAsync(email);

                return Ok(user);
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpPost("current/get")]
        public async Task<IActionResult> GetUserByNameAndEmail([FromForm]ClaimsUserModel model)
        {
            Console.WriteLine("started");

            try
            {
                User user = await repository.GetUserByNameAndEmailAsync(model);

                return Ok(user);
            }
            catch(Exception e)
            {

                Console.WriteLine(e.Message);
                return NotFound();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetUserByNameAndPassAsync([FromForm]LoginModel model)
        {
            try
            {
                User user = await repository.GetUserByNameAndPasswordAsync(model);

                TokenModel tokenModel = new TokenModel
                {
                    Name = user.Name,
                    Email = user.Email,
                    Role = user.Role
                };

                string token = tokenService.CreateJwtToken(tokenModel);

                return Ok(token);
            }
            catch
            {
                return BadRequest();
                
            }

        }

        [HttpPost("likes/add")]
        public async Task AddLikeAsync([FromForm]LikeModel model)
        {
            await repository.AddLikeAsync(model);
        }

        [HttpPost("subscribers/add")]
        public async Task AddSubAsync([FromForm]SubModel model)
        {
            await repository.AddSubscriberAsync(model);
        }

        [HttpPost("subscribers/{id}")]
        public async Task ChangeFriedsheepAsync(long id)
        {
            await repository.ChangeFriendshipAsync(id);
        }

        [HttpPost("photos/add")]
        public async Task<IActionResult> AddPhotoAsync([FromForm]PhotoModel model)
        {
            await repository.AddPhotoAsync(model);

            return Ok();
        }

        [HttpPost("photos/delete")]
        public async Task<IActionResult> DeletePhotoAsync([FromForm] long id)
        {
            await repository.RemovePhotoAsync(id);

            return Ok();
        }

        [HttpPost("photos/{id}")]
        public async Task MakePhotoMainAsync(long id)
        {
            await repository.MakePhotoMainAsync(id);
        }

        [HttpPost("notices/add")]
        public async Task AddNoticeAsync([FromForm]NoticeModel model)
        {
            await repository.AddNoticeAsync(model);
        }

        [HttpGet("notices/handle/user/{id}")]
        public async Task<IActionResult> HandleNoticesAsync(long id)
        {
            await repository.HandleNoticesAsync(id);

            return Ok(new { message = "updated" });
        }
    }
}
