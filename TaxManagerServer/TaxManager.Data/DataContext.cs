using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManager.Core.Models;
using TaxManager.Core.Models.TaxManager.Core.Models;

namespace TaxManager.Data
{
    public class DataContext
    {
        public List<User> Users { get; set; }
        public List<Document> Documents { get; set; }
        public List<Folder> Folders{ get; set; }
        public DataContext()
        {
            Users = new List<User>();
            Users.Add(new User
            {
                UserId = 1,
                Email = "dd",
                Password = "22222",
                Permissions = { "" },
                Role = "user",
                Username = "ddd"
            });
            Documents = new List<Document>();
            Folders = new List<Folder>();
        }
    }
}