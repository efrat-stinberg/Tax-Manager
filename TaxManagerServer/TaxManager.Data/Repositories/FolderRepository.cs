using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models.TaxManager.Core.Models;
using TaxManager.Core.Repositories;

namespace TaxManager.Data.Repositories
{
    public class FolderRepository : IFolderRepository
    {
        private readonly DataContext _context;
        public FolderRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Folder folder)
        {
            if (folder == null)
            {
                throw new ArgumentNullException(nameof(folder));
            }
            _context.Folders.Add(folder);
        }

        public void Delete(int folderId)
        {
            var folder = _context.Folders.FirstOrDefault(f => f.FolderId == folderId);
            if (folder == null)
            {
                throw new KeyNotFoundException("Folder not found.");
            }
            _context.Folders.Remove(folder);
        }

        public List<Folder> GetAll()
        {
            return _context.Folders.ToList();
        }

        public Folder GetById(int folderId)
        {
            var folder = _context.Folders.FirstOrDefault(f => f.FolderId == folderId);
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
            var existingFolder = _context.Folders.FirstOrDefault(f => f.FolderId == folder.FolderId);
            if (existingFolder == null)
            {
                throw new KeyNotFoundException("Folder not found.");
            }
            //_context.Entry(existingFolder).CurrentValues.SetValues(folder);
        }
    }
}