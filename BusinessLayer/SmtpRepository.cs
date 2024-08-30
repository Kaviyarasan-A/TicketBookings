using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.entity;

namespace BusinessLayer
{
    public interface ISmtpRepository
    {
        public void SendEmail(string fromAddress, string password, string ToAddress, string Body);
    }

    public class SmtpRepository : ISmtpRepository
    {
        public void SendEmail(string fromAddress, string password, string ToAddress, string Body)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(fromAddress, "xyrimgzrvhltvczw")

            };


            try
            {
                Console.WriteLine("sending email ");
                email.Send(fromAddress, ToAddress, password, Body);
                Console.WriteLine("email sent ");
            }
            catch (SmtpException e)
            {
                Console.WriteLine(e);
            }

        }

    }




}

