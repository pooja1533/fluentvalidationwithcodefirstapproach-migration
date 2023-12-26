using Fluent.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fluent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluentController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public FluentController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // GET: api/<FluentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FluentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FluentController>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            var validationRules = new CustomerValidatior();
            var validationResult = validationRules.Validate(customer);
            if (!validationResult.IsValid) 
            {
                return BadRequest();
            }
            else
            {
                _databaseContext.Customers.Add(customer);
                _databaseContext.SaveChanges();
            }
            return Ok(customer);
        }

        // PUT api/<FluentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FluentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
