using Microsoft.EntityFrameworkCore;
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
            using (var db = new VisionServerContext())
            {
                db.Database.Migrate();
                db.SaveChanges();

                var userToAdd = new User
                {
                    Name = "Schatzipuhh",
                    LoginName = "Pupsii",
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
