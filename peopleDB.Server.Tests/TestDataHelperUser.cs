using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using peopleDB.Server.Models.Entities;

namespace peopleDB.Server.Tests
{
    static class TestDataHelperUser
    {
        public static List<User> GetFakeUserList()
        {
            return new List<User>()
            {       
                new User
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "test@test.com",
                    Password = "123-456-7890"
                },
                new User
                {
                    Id = 2,
                    Name = "Mark Luther",
                    Email = "test@test.com",
                    Password = "123-456-7890"
                }
            };
        }
    }
}
