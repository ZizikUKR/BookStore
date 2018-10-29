using Domain1.Abstract;
using Domain1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Domain1.Concret
{
    public class EmailSettings
    {
        public string MailToAdress = "orders@example.com";
        public string MailFromAdress = "bookstore@example.com";
        public bool UseSsl = true;
        public string UserName = "MSmptUsername";
        public string Password = "MSmptPassword";
        public string ServerName = "smpt.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"c:\book_strore_emails";
    }


    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
        }
        public void Processor(Cart cart, ShoppingDetails shoppingDetails)
        {
            using(var smptClient = new SmtpClient())
            {
                smptClient.EnableSsl = emailSettings.UseSsl;
                smptClient.Host = emailSettings.ServerName;
                smptClient.Port = emailSettings.ServerPort;
                smptClient.UseDefaultCredentials = false;
                smptClient.Credentials = new NetworkCredential(emailSettings.UserName, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smptClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smptClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smptClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("New order was processed")
                    .AppendLine("-----")
                    .AppendLine("Stuffs:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Quantity * line.Book.Price;

                }
                body.AppendFormat("All summ:{0:c}", cart.ComputeTotalValue())
                        .AppendLine("----")
                        .AppendLine("Delivery:")
                        .AppendLine(shoppingDetails.Name)
                        .AppendLine(shoppingDetails.Line1)
                        .AppendLine(shoppingDetails.Line2 ?? "")
                        .AppendLine(shoppingDetails.Line3 ?? "")
                        .AppendLine(shoppingDetails.City)
                        .AppendLine(shoppingDetails.Country)
                        .AppendLine("---")
                        .AppendFormat("GiftWrap: {0}", shoppingDetails.GiftWrap ? "Yes" : "No");

                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAdress,
                    emailSettings.MailToAdress,
                    "New order was sent",
                    body.ToString());

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;
                }
                smptClient.Send(mailMessage);
            }
        }
    }
}
