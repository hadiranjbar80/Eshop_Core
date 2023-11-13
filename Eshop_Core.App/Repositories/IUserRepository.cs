using Eshop_Core.App.Context;
using Eshop_Core.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop_Core.App.Repositories
{
    public interface IUserRepository
    {
        bool IsExistUserByEmail(string email);
        void AddUser(Users users);
        Users GetUserForLogin(string email, string password);
    }

    public class UserRepository : IUserRepository
    {
        private EshopContext _context;

        public UserRepository(EshopContext context)
        {
            _context = context;
        }

        public void AddUser(Users users)
        {
            _context.Add(users);
            _context.SaveChanges();
        }

        public Users GetUserForLogin(string email, string password)
        {
            return _context.Users.
                 SingleOrDefault(u => u.Email == email && u.Password == password);
        }

        public bool IsExistUserByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}
