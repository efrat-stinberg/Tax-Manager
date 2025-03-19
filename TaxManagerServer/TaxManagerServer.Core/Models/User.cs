using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManager.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<string> Permissions { get; set; }

        public User()
        {
            Permissions = new List<string>();
        }

        // מתודה להוספת הרשאה
        public void AddPermission(string permission)
        {
            if (!Permissions.Contains(permission))
            {
                Permissions.Add(permission);
            }
        }

        public void RemovePermission(string permission)
        {
            if (Permissions.Contains(permission))
            {
                Permissions.Remove(permission);
            }
        }

        public bool HasPermission(string permission)
        {
            return Permissions.Contains(permission);
        }

        public void UpdateUserDetails(string username, string email, string role)
        {
            Username = username;
            Email = email;
            Role = role;
        }

        public bool ValidatePassword(string password)
        {
            return Password == password; 
        }
    }
}
