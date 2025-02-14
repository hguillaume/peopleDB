using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using peopleDB.Server.Data;
using peopleDB.Server.Models;
using peopleDB.Server.Models.Entities;

namespace peopleDB.Server.Controllers
{
    // localhost:port/api/Users
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "GetUsers")]
        public IActionResult Get()
        {
            var allUsers = dbContext.Users.ToList();
            return Ok(allUsers);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddUserDto userDto)
        {
            var user = new User
            {
                name = userDto.name,
                email = userDto.email,
                password = userDto.password
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var user = dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] AddUserDto userDto)
        {
            var user = dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            user.name = userDto.name;
            user.email = userDto.email;
            user.password = userDto.password;
            dbContext.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var user = dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
