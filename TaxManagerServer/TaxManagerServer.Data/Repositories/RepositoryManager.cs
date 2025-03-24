using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxManager.Core.Models;
using TaxManager.Core.Models.TaxManager.Core.Models;
using TaxManager.Data;
using TaxManagerServer.Core.Repository;

namespace TaxManagerServer.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        public IUserRepository Users { get; }
        public IRepository<Document> Documents { get; }
        public IRepository<Folder> Folders { get; }

        public RepositoryManager(DataContext context, IUserRepository userRepository, IRepository<Document> documentRepository, IRepository<Folder> folderRepository)
        {
            _context = context;
            Users = userRepository;
            Documents = documentRepository;
            Folders = folderRepository;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
