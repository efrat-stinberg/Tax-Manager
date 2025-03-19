using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models;

namespace TaxManager.Core.Services
{
    public interface IDocumentService
    {
        void Add(Document document);
        Document GetById(int documentId);
        IEnumerable<Document> GetAll();
        void Update(Document document);
        void Delete(int documentId);
    }
}
