using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StudentManagement_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        // GET: api/Grade
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Grade/5
        [HttpGet("{id}", Name = "GetGrade")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Grade
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Grade/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
