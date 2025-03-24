using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models;

namespace TaxManagerServer.Core.DTOs
{
    public class FolderDTO
    {
        public string FolderName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Collection<Document> Documents { get; set; }
    }
}
