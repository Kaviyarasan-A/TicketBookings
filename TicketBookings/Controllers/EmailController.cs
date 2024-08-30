using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.Extensions.Configuration;
using BusinessLayer.entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        public readonly ISmtpRepository _smtpRepository;
        public readonly IConfiguration _configuration;

        public EmailController(ISmtpRepository smtpRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _smtpRepository = smtpRepository;
        }
        // GET: api/<EmailController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmailController>
        [HttpPost]
        public ActionResult<SmtpEmail> Post([FromBody] SmtpEmail value)
        {
            var Fromaddress = _configuration.GetValue<string>("SMTP:Fromaddress");
            var Password = _configuration.GetValue<string>("SMTP:Password");
            _smtpRepository.SendEmail(Fromaddress, Password, value.ToAddress, value.Body);
            return Ok();
        }

        // PUT api/<EmailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
