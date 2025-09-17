using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Models;

namespace Test_Algorithm
{
    public class TestDB
    {
        [Fact]
        public void TestValidatorDb()
        {
            var User = new User();
            User.UserName = "test";
            User.Password = "test";
            User.UserGmail = "testf@gmail.com";

            UserdbContext dbContext = new UserdbContext();
            Validator.ValidateObject(User, new ValidationContext(User), true);
            dbContext.Add(User);
            dbContext.SaveChanges();
        }


    }
}
