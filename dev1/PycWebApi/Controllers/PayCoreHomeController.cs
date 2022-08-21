using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PycWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PycHomeController : ControllerBase
    {
        // GET: api/<PycHomeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PycHomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value" + id;
        }

        // POST api/<PycHomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PycHomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PycHomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
