using NUnit.Framework;
using WebApplicationEonix.Models;
using WebApplicationEonix.Repositories;
using System.Linq;
using System;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationEonix.DataAccess;
using Microsoft.Extensions.Configuration;

namespace TestProject
{
    public class Tests
    {
        private readonly EonixContext _context;
        private readonly UserRepository _userRepository;

        public Tests()
        {
            var services = new ServiceCollection();
            var serviceProvider = services.BuildServiceProvider();
            var _uowProvider = new UowProvider(serviceProvider);

            this._context = new EonixContext();
            this._userRepository = new UserRepository(this._context, _uowProvider);
        }

        [Test]
        public void GetUser()
        {
            var result = this._userRepository.GetUser();
            Assert.NotNull(result);
        }


        [Test]
        public void GetUserById()
        {
            var user = _context.Users.FirstOrDefault();
            if (user != null)
            {
                var result = this._userRepository.GetUserById(user.Id.ToString());
                Assert.NotNull(result);
            }
            else
            {
                Assert.Fail("no user");
            }
        }

        [Test]
        public void PostUser()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "UnitTestPostUser",
                LastName = "UnitTestPostUser",
            };
            var result = this._userRepository.PostUser(user);
            Assert.NotNull(result);
        }

        [Test]
        public void DeleteUser()
        {
            var user = this._userRepository.GetUser("UnitTestPostUser").FirstOrDefault();

            if (user != null)
            {
                var result = this._userRepository.DeleteUser(user.Id.ToString());
                Assert.NotNull(result);
            }
            else
            {
                var createUser = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "UnitTestPostUser",
                    LastName = "UnitTestPostUser",
                };
                var result = this._userRepository.PostUser(createUser);
                var result2 = this._userRepository.DeleteUser(result.Id.ToString());
                Assert.NotNull(result);
            }
        }
    }
}
