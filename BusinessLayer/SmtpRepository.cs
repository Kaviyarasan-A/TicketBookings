using FluentAssertions.Common;
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
    public class SmtpRepository
    {
        private readonly IConfiguration Configuration;

        public SmtpRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public static void SendEmail(string fromAddress, string password,string ToAddress,string Body)
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
                email.Send(fromAddress, ToAddress,password,Body);
                Console.WriteLine("email sent ");
            }
            catch (SmtpException e)
            {
                Console.WriteLine(e);
            }

        }
     
    }
}
