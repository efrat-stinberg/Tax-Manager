using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models;

namespace TaxManager.Core.Services
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        void Update(int id, User updatedUser);
        void Add(User newUser);
        void Delete(int id);
    }
}
