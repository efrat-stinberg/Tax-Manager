using Microsoft.AspNetCore.Mvc;
using TaxManager.Core.Models;
using TaxManager.Core.Services;
using TaxManager.Service;

namespace TaxManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAll();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound(); 
            }
            return Ok(user); 
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User newUser)
        {
            if (newUser == null)
            {
                return BadRequest(); 
            }

            _userService.Add(newUser); 
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser); 
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User updatedUser)
        {
            var existingUser = _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound(); 
            }

            _userService.Update(id, updatedUser); 
            return NoContent(); 
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound(); 
            }

            _userService.Delete(id); 
            return NoContent();
        }
    }
}