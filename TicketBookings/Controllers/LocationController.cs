using DataAccessLayer;
using DataAccessLayer.entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketBookings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        ILocationRepository rep = null;
        public LocationController(ILocationRepository repo)
        {
            rep = repo;
        }
        // GET: api/<LocationController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(rep.GetAllLocation());
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string name)
        {
            try
            {
                return Ok(rep.GetLocationByName(name));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST api/<LocationController>
        [HttpPost]
        public IActionResult Post([FromBody] Location value)
        {
            try
            {
                rep.InsertLocation(value);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public IActionResult Put( [FromBody] Location value)
        {
            try
            {
                rep.UpdateLocation(value);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                rep.DeleteLocation(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
