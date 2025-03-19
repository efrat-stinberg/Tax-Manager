using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models;

namespace TaxManager.Core.Repositories
{
    public interface IDocumentRepository
    {
        Document GetById(int documentId); // Retrieve a document by its ID
        IEnumerable<Document> GetAll(); // Retrieve all documents
        void Add(Document document); // Add a new document
        void Update(Document document); // Update an existing document
        void Delete(int documentId); // Delete a document by its ID

    }
}
