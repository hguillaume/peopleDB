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
                    id = 1,
                    name = "John Doe",
                    email = "test@test.com",
                    password = "123-456-7890"
                },
                new User
                {
                    id = 2,
                    name = "Mark Luther",
                    email = "test@test.com",
                    password = "123-456-7890"
                }
            };
        }
    }
}
