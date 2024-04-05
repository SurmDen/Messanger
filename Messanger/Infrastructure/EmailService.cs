using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;


namespace Messanger.Infrastructure
{
    public class EmailService
    {
        public static async Task SendEmailAsync(string email, int password)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Surmanidze D. application", "surmanidzedenis609@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("Dear NotifyerPro User", email));
            emailMessage.Subject = "Address confirmation";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = password.ToString()
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("surmanidzedenis609@gmail.com", "cfyofdfwilntaapq");
                var answer =  await client.SendAsync(emailMessage);

                //cfyofdfwilntaapq
                await client.DisconnectAsync(true);
            }
        }
    }
}
