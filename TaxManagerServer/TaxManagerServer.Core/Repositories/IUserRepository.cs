using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models;

namespace TaxManager.Core.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        void Update(User user);
        void Add(User user);
        void Delete(User user);

    }
}
