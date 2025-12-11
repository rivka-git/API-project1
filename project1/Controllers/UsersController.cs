using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Text.Json;
using Services;
using static project1.Controllers.Userscontroller;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Userscontroller : ControllerBase
    {
        IUserServices _s;
        public Userscontroller(IUserServices i)
        {
            _s = i;
        }

        //GET: api/<users>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _s.GetUsers();
        }

        // GET api/<users>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
           User user= await _s.GetUserById(id);
            if (user!=null)
            {
                return Ok(user);
            }       
          return NoContent();
        }
        // POST api/<users>

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {

            User res = await _s.AddNewUser(user);
            if (res!=null)
            {
                return CreatedAtAction(nameof(Get), new { id = res.UserId }, res);
            }
            else
                return BadRequest();
        }

        //POST
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login([FromBody] User user)
        {
            User res = await _s.Login(user);
            if(res!=null)
            {
                return Ok(res);
            }
                 
            return NotFound();
        }



        // PUT api/<users>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User value)
        {
            User res = await _s.update(id, value);
            if (res!= null)
            {
                return CreatedAtAction(nameof(Get), new { id = value.UserId }, res);
            }
            else
                return BadRequest();  
        }

        // DELETE api/<users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
