using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxManager.Core.Models;
using TaxManager.Core.Repositories;

namespace TaxManager.Data.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DataContext _context;

        public DocumentRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Document document)
        {
            _context.Documents.Add(document);
        }

        public void Delete(int documentId)
        {
            var document = _context.Documents.FirstOrDefault(d => d.DocumentId == documentId);
            if (document != null)
            {
                _context.Documents.Remove(document);
            }
        }

        public IEnumerable<Document> GetAll()
        {
            return _context.Documents.ToList(); // Retrieves all documents
        }

        public Document GetById(int documentId)
        {
            return _context.Documents.FirstOrDefault(d => d.DocumentId == documentId); // Retrieves the document by ID or returns default
        }

        public void Update(Document document)
        {
            //_context.Documents.Update(document);
        }
    }
}
