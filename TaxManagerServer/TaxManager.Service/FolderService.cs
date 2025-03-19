using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models.TaxManager.Core.Models;
using TaxManager.Core.Repositories;
using TaxManager.Core.Services;

namespace TaxManager.Service
{
    public class FolderService : IFolderService
    {
        private readonly IFolderRepository _folderRepository;

        public FolderService(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public void Add(Folder folder)
        {
            if (folder == null)
            {
                throw new ArgumentNullException(nameof(folder));
            }
            _folderRepository.Add(folder);
        }

        public void Delete(int folderId)
        {
            var folder = _folderRepository.GetById(folderId);
            if (folder == null)
            {
                throw new KeyNotFoundException("Folder not found.");
            }
            _folderRepository.Delete(folderId);
        }

        public IEnumerable<Folder> GetAll()
        {
            return _folderRepository.GetAll();
        }

        public Folder GetById(int folderId)
        {
            var folder = _folderRepository.GetById(folderId);
            if (folder == null)
            {
                throw new KeyNotFoundException("Folder not found.");
            }
            return folder;
        }

        public void Update(Folder folder)
        {
            if (folder == null)
            {
                throw new ArgumentNullException(nameof(folder));
            }
            var existingFolder = _folderRepository.GetById(folder.FolderId);
            if (existingFolder == null)
            {
                throw new KeyNotFoundException("Folder not found.");
            }
            _folderRepository.Update(folder);
        }
    }
}
