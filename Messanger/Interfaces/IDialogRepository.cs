using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Helpers;
using UserManager.Models;

namespace Messanger.Interfaces
{
    public interface IDialogRepository
    {
        public Task<Dialog> CreateDialog(DialogModel model);

        public Task<Dialog> GetDialog(DialogModel model);

        public Task SaveMessage(MessageModel model);

        public Task<Dialog> GetDialogByNameAsync(string name);

        public Task<List<Dialog>> GetUserDialogsAsync(long id);
    }
}
