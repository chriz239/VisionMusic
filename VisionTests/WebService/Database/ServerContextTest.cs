using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisionLib.Models;
using VisionWebService.Database;
using Xunit;

namespace VisionTests.WebService.Database
{
    public class ServerContextTest
    {
        [Fact]
        public void CreateUser()
        {
            using (var db = new ServerContext())
            {
                var userToAdd = new User
                {
                    Name = "Schatzipuh",
                    LoginName = "Pupsi",
                    Password = "secret"
                };
                db.Users.Add(userToAdd);
                db.SaveChanges();

                var addedUser = db.Users.Single(u => u.UserID == userToAdd.UserID);

                Assert.True(addedUser.LoginName == userToAdd.LoginName);
                Assert.True(addedUser.Password == userToAdd.Password);
            }

            
        }
    }
}
