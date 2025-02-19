// Tools->Options->NuGet Package Manager->Package Sources->Remove offline office

using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using peopleDB.Server.Controllers;
using peopleDB.Server.Data;
using peopleDB.Server.Models.Entities;

namespace peopleDB.Server.Tests
{
    //[TestClass]
    public sealed class TestUsersControllerRealDbOld
    {
        private WebApplicationBuilder builder;
        private DbContextOptions<ApplicationDbContext> options;
        private ApplicationDbContext dbContext;
        private UsersController users;

        public TestContext TestContext { get; set; }

        public TestUsersControllerRealDbOld()
        {
            this.builder = WebApplication.CreateBuilder();
            this.options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .Options;
            this.dbContext = new ApplicationDbContext(options);
            this.users = new UsersController(dbContext);
        }

        //[TestMethod]
        public void TestMethodFullVarsOld()
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder();
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .Options;
            ApplicationDbContext dbContext = new ApplicationDbContext(options);
            UsersController users = new UsersController(dbContext);
            IActionResult answer = users.Get();
            Type type1 = answer.GetType();
            Type type2 = typeof(OkObjectResult);
            Assert.IsTrue(type1 == type2);
        }

        public User AddUser()
        {
            ObjectResult? answer = users.Add(
                new Models.AddUserDto
                {
                    Name = "Test",
                    Email = "Test@test.com",
                    Password = "Test123456"
                }
            ) as ObjectResult;

            return answer.Value as User;
        }

        public void WriteTestContext(IActionResult answer)
        {
            
            
            var result = answer as ObjectResult;

            WriteTestContext(result);
        }
        public void WriteTestContext(ObjectResult? answer)
        {
            TestContext.WriteLine("Status Code: " + answer.StatusCode.ToString());
            TestContext.WriteLine(JsonConvert.SerializeObject(answer.Value, Formatting.Indented));
            //return answer.StatusCode.ToString();
        }

        [TestMethod]
        public void TestMethodGetAll()
        {
            IActionResult answer = users.Get();
            OkObjectResult? result = answer as OkObjectResult;
            List<User> value = result.Value as List<User>;
            WriteTestContext(answer);
            Assert.IsNotNull(value);
        }

        [TestMethod]
        public void TestAddUserMethod()
        {
            User user = AddUser();
            TestContext.WriteLine(JsonConvert.SerializeObject(user, Formatting.Indented));
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestAddIncomplete()
        {
            ObjectResult? answer = users.Add(
                new Models.AddUserDto
                {
                    Name = "Test",
                    Email = "Test",
                    Password = ""
                }
            ) as ObjectResult;

            WriteTestContext(answer);
            Assert.AreNotEqual(201, answer.StatusCode);
        }

        [TestMethod]
        public void TestGet()
        {
            User addUser = AddUser();
            IActionResult answer = users.Get(addUser.Id);
            OkObjectResult? result = answer as OkObjectResult;
            User user = result.Value as User;
            WriteTestContext(answer);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestGetWrongId()
        {
            IActionResult answer = users.Get(0);
            NotFoundObjectResult? result = answer as NotFoundObjectResult;
            WriteTestContext(answer);
            Assert.AreNotEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestUpdate()
        {
            User user = AddUser();
            ObjectResult? answer = users.Update(
                user.Id,
                new Models.AddUserDto
                {
                    Name = "Test2",
                    Email = "Test2@test.com",
                    Password = "Test123456"
                }
            ) as ObjectResult;
            WriteTestContext(answer);
            Assert.AreEqual(200, answer.StatusCode);
        }

        [TestMethod]
        public void TestUpdateIncomplete()
        {
            User user = AddUser();
            ObjectResult? answer = users.Update(
                user.Id,
                new Models.AddUserDto
                {
                    Name = "Test2",
                    Email = "Test2",
                    Password = ""
                }
            ) as ObjectResult;
            WriteTestContext(answer);
            Assert.AreNotEqual(200, answer.StatusCode);
        }

        [TestMethod]
        public void TestUpdateWrongId()
        {
            NotFoundObjectResult? answer = users.Update(
                0,
                new Models.AddUserDto
                {
                    Name = "Test2",
                    Email = "Test2",
                    Password = "Test2"
                }
            ) as NotFoundObjectResult;
            WriteTestContext(answer);
            Assert.AreNotEqual(200, answer.StatusCode);
        }

        [TestMethod]
        public void TestDelete()
        {
            User user = AddUser();
            IActionResult answer = users.Delete(user.Id);
            OkObjectResult? result = answer as OkObjectResult;
            WriteTestContext(answer);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestDeleteWrongId()
        {
            IActionResult answer = users.Delete(0);
            var result = answer as NotFoundObjectResult;
            WriteTestContext(answer);
            Assert.AreNotEqual(200, result.StatusCode);
        }
    }
}
