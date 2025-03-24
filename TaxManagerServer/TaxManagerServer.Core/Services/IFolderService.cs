using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models.TaxManager.Core.Models;

namespace TaxManager.Core.Services
{
    public interface IFolderService
    {
        Task AddAsync(Folder folder);
        Task<Folder> GetByIdAsync(int folderId);
        Task<IEnumerable<Folder>> GetAllAsync();
        Task UpdateAsync(Folder folder);
        Task DeleteAsync(int folderId);
    }
}
