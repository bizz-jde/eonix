using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationEonix.DataAccess;
using WebApplicationEonix.Models;

namespace WebApplicationEonix.Repositories
{
    public class UserRepository
    {
        private readonly EonixContext _context;
        private readonly IUowProvider _uowProvider;

        public UserRepository(EonixContext context, IUowProvider uowProvider)
        {
            this._context = context;
            _uowProvider = uowProvider;

        }

        public List<User> GetUser(string filter = "")
        {
            using (var uow = _uowProvider.CreateUnitOfWork(false))
            {
                List<User> result = _context.Users
                .Where(w => (w.FirstName ?? "").Trim().Contains((filter ?? "").Trim()) || (w.LastName ?? "").Trim().Contains((filter ?? "").Trim()))
                .ToList();
                return result;
            }
        }

        public User GetUserById(string id)
        {
            using (var uow = _uowProvider.CreateUnitOfWork(false))
            {
                User result = _context.Users.FirstOrDefault(f => f.Id.ToString() == id);
                return result;
            }
        }

        public User PostUser(User value)
        {
            using (var uow = _uowProvider.CreateUnitOfWork(false))
            {
                User user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = value.FirstName,
                    LastName = value.LastName
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
        }

        public User PutUser(string id, User value)
        {
            using (var uow = _uowProvider.CreateUnitOfWork(false))
            {
                User user = _context.Users.FirstOrDefault(f => f.Id.ToString() == id);
                if (user != null)
                {
                    user.FirstName = value.FirstName;
                    user.LastName = value.LastName;

                    _context.Users.Update(user);
                    _context.SaveChanges();
                }

                return user;
            }
        }

        public User PatchUser(string id, User value)
        {
            using (var uow = _uowProvider.CreateUnitOfWork(false))
            {
                User user = _context.Users.FirstOrDefault(f => f.Id.ToString() == id);
                if (user != null)
                {
                    if (user.FirstName != null) user.FirstName = value.FirstName;
                    if (user.LastName != null) user.LastName = value.LastName;

                    _context.Users.Update(user);
                    _context.SaveChanges();
                }

                return user;
            }
        }

        public User DeleteUser(string id)
        {
            using (var uow = _uowProvider.CreateUnitOfWork(false))
            {
                User user = _context.Users.FirstOrDefault(f => f.Id.ToString() == id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
                return user;
            }
        }


    }
}
