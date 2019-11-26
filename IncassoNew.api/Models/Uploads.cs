using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class Uploads
    {
        public Uploads()
        {
            Invoices = new HashSet<Invoices>();
            UploadAdministrators = new HashSet<UploadAdministrators>();
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public string PhysicalFilePath { get; set; }
        public string PhysicalFileName { get; set; }
        public string FileType { get; set; }
        public DateTime? Date { get; set; }
        public bool IsOverride { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }

        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<UploadAdministrators> UploadAdministrators { get; set; }
    }
}
