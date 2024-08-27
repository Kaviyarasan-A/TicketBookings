using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.entity
{
    public class SmtpEmail
    {
        public string Fromaddress { get; set; }
        public string Password { get; set; }
        public string ToAddress { get; set; }
        public string Body { get; set; } 

    }
}
