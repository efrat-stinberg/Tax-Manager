using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxManager.Core.Models;
using TaxManager.Core.Models.TaxManager.Core.Models;
using TaxManager.Core.Services;
using TaxManagerServer.Core.Repository;

namespace TaxManager.Service
{
    public class FolderService : IFolderService
    {
        private readonly IRepository<Folder> _folderRepository;
        private readonly IRepositoryManager _repositoryManager;

        public FolderService(IRepository<Folder> folderRepository, IRepositoryManager repositoryManager)
        {
            _folderRepository = folderRepository;
            _repositoryManager = repositoryManager;
        }

        public async Task AddAsync(Folder folder)
        {
            if (folder == null)
            {
                throw new ArgumentNullException(nameof(folder));
            }
            await _folderRepository.AddAsync(folder); // Use AddAsync
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteAsync(int folderId)
        {
            var folder = await _folderRepository.GetByIdAsync(folderId); // Use GetByIdAsync
            if (folder == null)
            {
                throw new KeyNotFoundException("Folder not found.");
            }
            await _folderRepository.DeleteAsync(folder); // Use DeleteAsync
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<Folder>> GetAllAsync()
        {
            return await _folderRepository.GetAllAsync(); // Use GetAllAsync
        }

        public async Task<Folder?> GetByIdAsync(int folderId)
        {
            var folder = await _folderRepository.GetByIdAsync(folderId); // Use GetByIdAsync
            if (folder == null)
            {
                throw new KeyNotFoundException("Folder not found.");
            }
            return folder;
        }

        public async Task UpdateAsync(Folder folder)
        {
            if (folder == null)
            {
                throw new ArgumentNullException(nameof(folder));
            }
            var existingFolder = await _folderRepository.GetByIdAsync(folder.FolderId); // Use GetByIdAsync
            if (existingFolder == null)
            {
                throw new KeyNotFoundException("Folder not found.");
            }
            await _folderRepository.UpdateAsync(folder); // Use UpdateAsync
            await _repositoryManager.SaveAsync();
        }
    }
}
