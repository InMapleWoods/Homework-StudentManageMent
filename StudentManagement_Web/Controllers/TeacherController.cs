using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace StudentManagement_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        // GET: api/Teacher
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Teacher/5
        [HttpGet("{id}", Name = "GetTeacher")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Teacher
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Teacher/5
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
