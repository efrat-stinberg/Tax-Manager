using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models;
using TaxManager.Core.Models.TaxManager.Core.Models;

namespace TaxManager.Core.Repositories
{
    public interface IFolderRepository
    {
        List<Folder> GetAll();
        Folder GetById(int folderId);
        void Update(Folder folder);
        void Add(Folder folder);
        void Delete(int folderId);
    }
}
