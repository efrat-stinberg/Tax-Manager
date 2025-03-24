using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models.TaxManager.Core.Models;
using TaxManager.Core.Models;
using TaxManagerServer.Core.Repository;

namespace TaxManagerServer.Data.Repositories
{
    public interface IRepositoryManager
    {
        public IUserRepository Users { get; }
        IRepository<Document> Documents { get; }
        IRepository<Folder> Folders { get; }
        Task SaveAsync();

    }
}
