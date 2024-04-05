using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Helpers;
using UserManager.Models;
using Messanger.Interfaces;
using Microsoft.EntityFrameworkCore;
using AuthenticationManager.Infrastructure;
using AuthenticationManager.Models;

namespace Messanger.Models
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(DataContext context)
        {
            this.context = context;
        }

        private DataContext context;

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> users;

            try
            {
                users = context.Users
                .Include(u => u.Likes)
                .Include(u => u.Subscribers)
                .Include(u => u.Photos)
                .Include(u => u.Notices).ToList();

                foreach (User user in users)
                {
                    foreach (var list in user.Subscribers)
                    {
                        list.User = null;
                    }

                    foreach (var list in user.Photos)
                    {
                        list.User = null;
                    }

                    foreach (var list in user.Likes)
                    {
                        list.User = null;
                    }

                    foreach (var list in user.Notices)
                    {
                        list.User = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                users = null;
            }

            return await Task.FromResult(users);
        }

        public async Task CreateUserAsync(User user)
        {
            user.Role = "User";

            user.Password = PasswordHasher.GenerateHash(user.Password);

            await context.Users.AddAsync(user);

            await context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UpdateUserModel user)
        {
            User dbUser = await context.Users
                .Include(u => u.Likes)
                .Include(u => u.Subscribers)
                .Include(u => u.Notices)
                .Include(u => u.Photos)
                .FirstAsync(u => u.Id == user.Id);

            if (!string.IsNullOrEmpty(user.Password))
            {
                dbUser.Password = PasswordHasher.GenerateHash(user.Password);
            }

            if (!string.IsNullOrEmpty(user.Name))
            {
                dbUser.Name = user.Name;
            }

            if (!string.IsNullOrEmpty(user.City))
            {
                dbUser.City = user.City;
            }

            if (user.Age > 0)
            {
                dbUser.Age = user.Age;
            }

            context.Users.Update(dbUser);

            await context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(long id)
        {
            User deleted = await context.Users.FirstAsync(u=>u.Id == id);

            context.Users.Remove(deleted);

            await context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(long id)
        {
            User user = await context.Users
                .Include(u => u.Likes)
                .Include(u => u.Subscribers)
                .Include(u => u.Notices)
                .Include(u => u.Photos)
                .FirstAsync(u => u.Id == id);

            foreach (var list in user.Subscribers)
            {
                list.User = null;
            }

            foreach (var list in user.Photos)
            {
                list.User = null;
            }

            foreach (var list in user.Likes)
            {
                list.User = null;
            }

            foreach (var list in user.Notices)
            {
                list.User = null;
            }

            return user;
        }

        public async Task<User> GetUserByNameAndPasswordAsync(LoginModel model)
        {
            User user;

            try
            {
                user = await context.Users
                .Include(u => u.Likes)
                .Include(u => u.Subscribers)
                .Include(u => u.Notices)
                .Include(u => u.Photos)
                .FirstAsync(u => u.Name == model.Name && u.Password == PasswordHasher.GenerateHash(model.Password));

                foreach (var list in user.Subscribers)
                {
                    list.User = null;
                }

                foreach (var list in user.Photos)
                {
                    list.User = null;
                }

                foreach (var list in user.Likes)
                {
                    list.User = null;
                }

                foreach (var list in user.Notices)
                {
                    list.User = null;
                }

                return user;
            }
            catch
            {
                user = null;
            }

            return user;
        }

        public async Task<User> GetUserByNameAndEmailAsync(ClaimsUserModel model)
        {
            User user;

            try
            {
                user = await context.Users
                .Include(u => u.Likes)
                .Include(u => u.Subscribers)
                .Include(u => u.Notices)
                .Include(u => u.Photos)
                .FirstAsync(u => u.Name == model.Name && u.Email == model.Email);

                foreach (var list in user.Subscribers)
                {
                    list.User = null;
                }

                foreach (var list in user.Photos)
                {
                    list.User = null;
                }

                foreach (var list in user.Likes)
                {
                    list.User = null;
                }

                foreach (var list in user.Notices)
                {
                    list.User = null;
                }

                Console.WriteLine(user.Email);

            }
            catch
            {
                user = null;
            }

            return user;
        }



        public async Task<User> GetUserByEmailAsync(string email)
        {
            User user;

            try
            {
                user = await context.Users
                .Include(u => u.Likes)
                .Include(u => u.Subscribers)
                .Include(u => u.Notices)
                .Include(u => u.Photos)
                .FirstAsync(u =>  u.Email == email);

                foreach (var list in user.Subscribers)
                {
                    list.User = null;
                }

                foreach (var list in user.Photos)
                {
                    list.User = null;
                }

                foreach (var list in user.Likes)
                {
                    list.User = null;
                }

                foreach (var list in user.Notices)
                {
                    list.User = null;
                }

                Console.WriteLine(user.Email);

            }
            catch
            {
                user = null;
            }

            return user;
        }


        public async Task AddLikeAsync(LikeModel model)
        {
            User receiver = await context.Users.Include(u=>u.Likes).FirstAsync(u=>u.Id == model.ReceiverId);

            foreach (var list in receiver.Likes)
            {
                list.User = null;
            }

            Like like;

            try
            {
                like = await context.Likes.Where(l => l.LikerId == model.CurrentUserId).FirstAsync();

                context.Likes.Remove(like);
            }
            catch
            {
                like = new Like()
                {
                    LikerName = model.CurrentUserName,
                    LikerId = model.CurrentUserId,
                    User = receiver
                };

                await context.Likes.AddAsync(like);
            }

            await context.SaveChangesAsync();
        }

        public async Task AddSubscriberAsync(SubModel model)
        {
            User target = await context.Users.Include(u => u.Subscribers)
                .FirstAsync(u => u.Id == model.TargetUserId);

            foreach (var list in target.Subscribers)
            {
                list.User = null;
            }

            Subscriber subscriber;

            try
            {
                subscriber = target.Subscribers.First(s => s.SubId == model.CurrentUserId);

                context.Subscribers.Remove(subscriber);
            }
            catch
            {
                subscriber = new Subscriber()
                {
                    SubName = model.CurrentUserName,
                    SubId = model.CurrentUserId,
                    User = target
                };

                await context.Subscribers.AddAsync(subscriber);
            }

            await context.SaveChangesAsync();
        }

        public async Task ChangeFriendshipAsync(long subId)
        {
            Subscriber subscriber = await context.Subscribers.FindAsync(subId);

            subscriber.IsFriend = !subscriber.IsFriend;

            context.Subscribers.Update(subscriber);

            await context.SaveChangesAsync();
        }

        public async Task AddPhotoAsync(PhotoModel model)
        {

            User current = await context.Users.FindAsync((long)int.Parse(model.CurrentUserId));

            Photo photo = new Photo()
            {
                Path = model.Path,
                User = current
            };

            await context.Photos.AddAsync(photo);

            await context.SaveChangesAsync();
        }

        public async Task MakePhotoMainAsync(long id)
        {
            Photo photo = await context.Photos.FindAsync(id);

            photo.IsMain = !photo.IsMain;

            context.Photos.Update(photo);

            await context.SaveChangesAsync();
        }

        public async Task RemovePhotoAsync(long id)
        {
            Photo photo = await context.Photos.FindAsync(id);

            context.Photos.Remove(photo);

            await context.SaveChangesAsync();
        }

        public async Task AddNoticeAsync(NoticeModel model)
        {
            User target = await context.Users.FirstAsync(u=>u.Id == model.TargetUserId);

            Notice notice = new Notice()
            {
                NotifyerId = model.CurrentUserId,
                NotifyerName = model.CurrentUserName,
                Context = model.Context,
                User = target
            };

            await context.Notices.AddAsync(notice);

            await context.SaveChangesAsync();
        }

        public async Task HandleNoticesAsync(long id)
        {
            User current = await context.Users.Include(u => u.Notices).FirstAsync(n=>n.Id == id);

            current.LastSeenNoticesCount = current.Notices.Count();

            context.Users.Update(current);

            await context.SaveChangesAsync();
        }
    }
}
