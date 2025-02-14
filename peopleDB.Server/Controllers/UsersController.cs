using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using peopleDB.Server.Data;

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
    }
}
