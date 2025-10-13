using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Core.Entities.MappingProfiles;

namespace Test_Algorithm
{
    public class FakerUser
    {
        private Faker<UserRequest> FakeUser;
        public UserRequest Request ()
        {
            FakeUser = new Faker<UserRequest> ()
                .RuleFor(u => u.Gmail, (f,u) => f.Internet.Email(u.Name))
                .RuleFor(u=>u.Name, (f,u) => f.Name.FirstName())
                .RuleFor(u=> u.Password, (f,u)=> f.Internet.Password());
            return FakeUser.Generate();

        }
    }
}
