using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManager.Core.Models
{
    public class Document
    {
        public int DocumentId { get; set; } // מזהה ייחודי למסמך
        public int UserId { get; set; } // מזהה המשתמש שהעלה את המסמך
        public string FilePath { get; set; } // מיקום הקובץ בענן
        public DateTime UploadDate { get; set; } // תאריך העלאת המסמך
        public string DocumentType { get; set; } // סוג המסמך (חשבונית, קבלה, טופס)
        public string Status { get; set; } // מצב המסמך (מאושר, ממתין לבדיקה)

        public Document() { }

        // קונסטרקטור
        public Document(int document, int userId, string filePath, string documentType, string status)
        {
            DocumentId = document; // יצירת מזהה ייחודי למסמך
            UserId = userId;
            FilePath = filePath;
            UploadDate = DateTime.UtcNow; // תאריך העלאה
            DocumentType = documentType;
            Status = status;
        }

        public string GetDocumentDetails()
        {
            return $"Document ID: {DocumentId}, User ID: {UserId}, Type: {DocumentType}, Status: {Status}, Uploaded on: {UploadDate}";
        }

        public void UpdateStatus(string newStatus)
        {
            Status = newStatus;
        }

        public string GetFilePath()
        {
            return FilePath;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(FilePath) && !string.IsNullOrEmpty(DocumentType);
        }
    }
}
