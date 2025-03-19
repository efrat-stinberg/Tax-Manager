using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models;
using TaxManager.Core.Repositories;
using TaxManager.Core.Services;

namespace TaxManager.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id); // מחזיר את המשתמש לפי מזהה
        }

        public void Update(int id, User updatedUser)
        {
            var existingUser = _userRepository.GetById(id);
            if (existingUser != null)
            {
                existingUser.Username = updatedUser.Username;
                existingUser.Email = updatedUser.Email;
                existingUser.Role = updatedUser.Role;
                existingUser.Permissions = updatedUser.Permissions;

                _userRepository.Update(existingUser); // מעדכן את המשתמש במאגר
            }
        }

        public void Add(User newUser)
        {
            _userRepository.Add(newUser); // מוסיף את המשתמש למאגר
        }

        public void Delete(int id)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
            {
                _userRepository.Delete(user); // מסיר את המשתמש מהמאגר
            }
        }
    }
}
