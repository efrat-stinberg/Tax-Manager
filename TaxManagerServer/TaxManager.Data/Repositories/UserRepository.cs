using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models;
using TaxManager.Core.Repositories;


namespace TaxManager.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id); 
        }

        public void Update(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;
                existingUser.Role = user.Role;
                existingUser.Permissions = user.Permissions;
            }
        }

        public void Add(User user)
        {
            _context.Users.Add(user);  
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user); 
        }
    }
}
