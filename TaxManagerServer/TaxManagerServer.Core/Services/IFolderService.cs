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
        void Add(Folder folder);
        Folder GetById(int folderId);
        IEnumerable<Folder> GetAll();
        void Update(Folder folder);
        void Delete(int folderId);
    }
}
