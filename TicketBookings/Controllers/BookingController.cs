using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using DataAccessLayer.entity;
using DataAccessLayer;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingRepository reg= null;

        public BookingController(IBookingRepository regs)
        {
            reg = regs;
        }
            // GET: api/<BookingController>
            [HttpGet]
        public IEnumerable<TicketBooking> Get()
        {
            return reg.SelectALLUser();
        }

        // GET api/<BookingController>/5
        [HttpGet("{Busname}")]
        public TicketBooking Get(string Busname)
        {
            return reg.SelectUserByUsername(Busname);
        }

        // POST api/<BookingController>
        [HttpPost]
        public void Post([FromBody] TicketBooking value)
        {
            reg.Registeruser(value);
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TicketBooking value)
        {
            reg.UpdateUser(value);
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{TicketId}")]
        public void Delete(long  TicketId)
        {
            reg.DeleteUser(TicketId);
        }
    }
}
