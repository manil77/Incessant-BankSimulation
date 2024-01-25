using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BankSimulation.Utility
{
    public class EmailSender
    {
        public static string SendEmail(string email, string htmlMessage)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();


                //SMTP for Email
                string subject = "Transaction Alert!";
                var userName = configuration["AppSettings:UserName"];
                string password = configuration["AppSettings:SmtpKey"];

                SendEmail(email, userName, password, subject, htmlMessage);

                return "Email Sent";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static async Task SendEmail(string toEmailAddress, string fromEmailAddress, string fromEmailpwd, string emailSubject, string emailMessage)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new System.Net.Mail.MailAddress(fromEmailAddress);
                SmtpClient smtp = new SmtpClient();

                #region Add these in config file
                smtp.Port = 587;

                smtp.EnableSsl = true;

                smtp.Host = "smtp.gmail.com";


                smtp.UseDefaultCredentials = false;
                #endregion
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromEmailAddress, fromEmailpwd);

                //recipient

                mail.To.Add(new MailAddress(toEmailAddress));

                mail.IsBodyHtml = true;


                mail.Subject = emailSubject;
                mail.Body = emailMessage;

                smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                string userState = "test msg";

                await Task.Run(() => smtp.SendAsync(mail, userState));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            //mail.Dispose();
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
        }


    }
}
