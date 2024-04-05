using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Helpers;
using UserManager.Models;
using Messanger.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Messanger.Models
{
    public class DialogRepository : IDialogRepository
    {
        public DialogRepository(DataContext context)
        {
            this.context = context;
        }

        private DataContext context;

        public async Task<Dialog> CreateDialog(DialogModel model)
        {
            string name = $"{model.FirstEmail}_{model.SecondEmail}";

            Dialog dialog = new Dialog()
            {
                ChatName = name
            };

            await context.Dialogs.AddAsync(dialog);

            await context.SaveChangesAsync();

            return dialog;
        }

        public async Task<Dialog> GetDialog(DialogModel model)
        {
            Dialog dialog;

            try
            {
                dialog = await context.Dialogs
                    .Where(d => d.ChatName == $"{model.FirstEmail}_{model.SecondEmail}" || d.ChatName == $"{model.SecondEmail}_{model.FirstEmail}")
                    .Include(d=>d.Messages)
                    .FirstAsync();

                foreach (Message message in dialog.Messages)
                {
                    message.Dialog = null;
                }
            }
            catch (Exception)
            {
                dialog = null;
            }

            return dialog;
        }

        public async Task SaveMessage(MessageModel model)
        {
            Dialog dialog = await context.Dialogs.FindAsync(model.DialogId);

            Message message = new Message
            {
                Context = model.Context,
                UserName = model.UserName,
                Dialog = dialog
            };

            await context.Messages.AddAsync(message);

            await context.SaveChangesAsync();
        }

        public async Task<Dialog> GetDialogByNameAsync(string name)
        {
            Dialog dialog = await context.Dialogs.FirstAsync(d=>d.ChatName == name);

            return dialog;
        }

        public async Task<List<Dialog>> GetUserDialogsAsync(long id)
        {
            User user = await context.Users.FindAsync(id);

            List<Dialog> dialogs;

            try
            {
                dialogs =  await context.Dialogs
                .Include(d => d.Messages)
                .Where(d => d.ChatName.Contains(user.Email))
                .ToListAsync();

                foreach (Dialog dialog in dialogs)
                {
                    foreach (Message message in dialog.Messages)
                    {
                        message.Dialog = null;
                    }
                }
            }
            catch (Exception)
            {
                dialogs = null;
            }

            return dialogs;
        }
    }
}
