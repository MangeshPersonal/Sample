using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIAuthentication.Controllers
{
    [Produces("application/json")]
    [Route("api/Sample")]
    public class SampleController : Controller
    {
        // GET: api/Sample
        [HttpGet]
        public Result Get()
        {

            var data = new List<object>
            {
                new User() { FirstName = "A" },
                new User() { FirstName = "B" },
                new User() { FirstName = "C" },
                new User() { FirstName = "D" }
            };

            return new Result(){Data = data,StatusCode = 101,StatusMessage = "OK",version = "1.0"};
        }

        // GET: api/Sample/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Sample
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Sample/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
