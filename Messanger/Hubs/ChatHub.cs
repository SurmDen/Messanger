using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserManager.Helpers;
using UserManager.Models;
using Microsoft.Extensions.Configuration;
using Messanger.Interfaces;

namespace Messanger.Hubs
{
    public class ChatHub : Hub
    {
        IUserRepository userRepository;

        IConfiguration configuration;

        IDialogRepository dialogRepository;

        public ChatHub(IConfiguration configuration, IUserRepository userRepository, IDialogRepository dialogRepository)
        {
            this.userRepository = userRepository;

            this.configuration = configuration;

            this.dialogRepository = dialogRepository;
        }

        public async Task Send(string message, string otherEmail)
        {
            string currentEmail = Context.User.FindFirst(ClaimTypes.Email).Value;

            //Dictionary<string, string> content = new Dictionary<string, string>()
            //{
            //    {"FirstEmail", currentEmail },
            //    {"SecondEmail", otherEmail }
            //};

            //var answer = await Sender.PostAsync(content, $"{configuration["UserService"]}/api/dialog/get");

            //string jsonDialog = await answer.Content.ReadAsStringAsync();

            //Dialog dialog = JsonConvert.DeserializeObject<Dialog>(jsonDialog);

            //Console.WriteLine($"sended message to group: {dialog.ChatName}");

            DialogModel dialogModel = new DialogModel()
            {
                FirstEmail = currentEmail,

                SecondEmail = otherEmail
            };

            Dialog dialog = await dialogRepository.GetDialog(dialogModel);

            await Clients.OthersInGroup(dialog.ChatName).SendAsync("Receive", message, currentEmail);
        }

        public override async Task OnConnectedAsync()
        {
            string otherEmail = Context.GetHttpContext().Request.Cookies["clientEmail"];

            string currentEmail = Context.User.FindFirst(ClaimTypes.Email).Value;

            //Dictionary<string, string> content = new Dictionary<string, string>()
            //{
            //    {"FirstEmail", currentEmail },
            //    {"SecondEmail", otherEmail }
            //};

            //var answer = await Sender.PostAsync(content, $"{configuration["UserService"]}/api/dialog/get");

            //string jsonDialog = await answer.Content.ReadAsStringAsync();

            //Dialog dialog = JsonConvert.DeserializeObject<Dialog>(jsonDialog);

            //Console.WriteLine($"connected to the chat: {dialog.ChatName}");

            DialogModel dialogModel = new DialogModel()
            {
                FirstEmail = currentEmail,

                SecondEmail = otherEmail
            };

            Dialog dialog = await dialogRepository.GetDialog(dialogModel);

            await Groups.AddToGroupAsync(Context.ConnectionId, dialog.ChatName);

            await base.OnConnectedAsync();
        }
    }
}
