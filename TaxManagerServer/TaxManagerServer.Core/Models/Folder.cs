﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManager.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text.Json.Serialization;

    namespace TaxManager.Core.Models
    {

        public class Folder
        {
            public int FolderId { get; set; } 
            public string FolderName { get; set; } 
            public int UserId { get; set; } 
            public DateTime CreatedDate { get; set; } 
            public Collection<Document> Documents { get; set; } 

            public Folder()
            {
                Documents = new Collection<Document>(); // Initialize the collection of documents
            }

            // Method to add a document to the folder
            public void AddDocument(Document document)
            {
                if (document == null)
                {
                    throw new ArgumentNullException(nameof(document), "Document cannot be null.");
                }

                // Check if the document already exists
                if (Documents.Any(d => d.DocumentId == document.DocumentId))
                {
                    throw new InvalidOperationException("Document already exists in the folder.");
                }

                Documents.Add(document);
            }

            // Removes a document from the folder
            public void RemoveDocument(Document document)
            {
                Documents.Remove(document);
            }

            // Clears all documents from the folder
            public void ClearDocuments()
            {
                Documents.Clear();
            }

            // Returns the count of documents in the folder
            public int GetDocumentCount()
            {
                return Documents.Count;
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
