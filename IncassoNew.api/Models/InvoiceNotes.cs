using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class InvoiceNotes
    {
        public int Id { get; set; }
        public DateTime? NoteDate { get; set; }
        public string Notes { get; set; }
        public string AddedByPortal { get; set; }
        public int? ParentId { get; set; }
        public string Status { get; set; }
        public int InvoiceId { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public bool IsEnterByUser { get; set; }

        public virtual Invoices Invoice { get; set; }
    }
}
