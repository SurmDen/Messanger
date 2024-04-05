using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Models;
using UserManager.Helpers;
using AuthenticationManager.Models;

namespace Messanger.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsersAsync();

        public Task CreateUserAsync(User user);

        public Task UpdateUserAsync(UpdateUserModel user);

        public Task DeleteUserAsync(long id);

        public Task<User> GetUserByIdAsync(long id);

        public Task<User> GetUserByNameAndPasswordAsync(LoginModel model);

        public Task<User> GetUserByNameAndEmailAsync(ClaimsUserModel model);

        public Task<User> GetUserByEmailAsync(string email);

        public Task AddLikeAsync(LikeModel model);

        public Task AddSubscriberAsync(SubModel model);

        public Task ChangeFriendshipAsync(long subId);

        public Task AddPhotoAsync(PhotoModel model);

        public Task RemovePhotoAsync(long id);

        public Task MakePhotoMainAsync(long photoId);

        public Task AddNoticeAsync(NoticeModel model);

        public Task HandleNoticesAsync(long currentUserId);
    }
}
