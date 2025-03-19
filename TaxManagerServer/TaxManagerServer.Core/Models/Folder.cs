using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManager.Core.Models
{
    using System;
    using System.Collections.Generic;

    namespace TaxManager.Core.Models
    {

        public class Folder
        {
            public int FolderId { get; set; } // Unique identifier for the folder
            public string FolderName { get; set; } // Name of the folder
            public DateTime CreatedDate { get; set; } // Creation date of the folder
            public List<int> DocumentIds { get; set; } // List of document IDs in the folder

            public Folder()
            {
                
            }
            // Constructor
            public Folder(int folderId, string folderName)
            {
                FolderId = folderId;
                FolderName = folderName;
                CreatedDate = DateTime.UtcNow; // Creation date of the folder
                DocumentIds = new List<int>(); // Initialize the list
            }

            // Adds a document ID to the folder
            public void AddDocument(int documentId)
            {
                if (!DocumentIds.Contains(documentId))
                {
                    DocumentIds.Add(documentId);
                }
            }

            // Removes a document ID from the folder
            public void RemoveDocument(int documentId)
            {
                DocumentIds.Remove(documentId);
            }

            // Clears all document IDs from the folder
            public void ClearDocuments()
            {
                DocumentIds.Clear();
            }

            // Returns the count of documents in the folder
            public int GetDocumentCount()
            {
                return DocumentIds.Count;
            }

            // Renames the folder
            public void RenameFolder(string newName)
            {
                FolderName = newName;
            }

            // Returns information about the folder
            public string GetFolderInfo()
            {
                return $"Folder ID: {FolderId}, Name: {FolderName}, Created Date: {CreatedDate}, Document Count: {GetDocumentCount()}";
            }
        }
    }
}
