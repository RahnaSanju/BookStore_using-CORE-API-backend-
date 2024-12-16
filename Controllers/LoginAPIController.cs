using BookStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("LoginAPI")]
    [ApiController]
    public class LoginAPIController : ControllerBase
    {
        BookDB bookDB = new BookDB();
        LoginDB loginDB = new LoginDB();

        // GET: api/<LoginAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginAPIController>/5

        [HttpGet]
        [Route("LoginUser/{username}/{password}")]
        public int Get(string username,string password)
        {
            int i=loginDB.CheckUser(username, password);
            if (i == 1)
            {
                int userid = loginDB.GetRegIDfromDB(username, password);
                return userid;
            }
            else
            {
                return 0;
            }

        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoginAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
