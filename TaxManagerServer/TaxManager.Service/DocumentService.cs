using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models;
using TaxManager.Core.Repositories;
using TaxManager.Core.Services;

namespace TaxManager.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public void Add(Document document)
        {
            _documentRepository.Add(document);
        }

        public void Delete(int documentId)
        {
            _documentRepository.Delete(documentId);
        }

        public Document GetById(int documentId)
        {
            return _documentRepository.GetById(documentId);
        }

        public IEnumerable<Document> GetAll()
        {
            return _documentRepository.GetAll();
        }

        public void Update(Document document)
        {
            _documentRepository.Update(document);
        }
    }
}
