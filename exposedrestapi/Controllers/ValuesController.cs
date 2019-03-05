using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace docker_examples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("ExternalValues")]
        public async Task<ActionResult<string>> GetExternal()
        {
            using(HttpClient client = new HttpClient())
            {
                try{
                    var response = await client.GetAsync("http://valuemachine/");
                    if (response.IsSuccessStatusCode) {
                        var deserializedString = await response.Content.ReadAsStringAsync();

                        return deserializedString;
                    } else {
                        return NotFound();
                    }
                }
                catch (HttpRequestException)
                {
                    return NotFound();
                }
            }
        }
    }
}
