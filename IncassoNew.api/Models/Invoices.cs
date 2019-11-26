using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class Invoices
    {
        public Invoices()
        {
            InvoiceNotes = new HashSet<InvoiceNotes>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
        public string DossierNo { get; set; }
        public string InvoiceNo { get; set; }
        public string Currency { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public float? Amount { get; set; }
        public float? Open { get; set; }
        public float? Paid { get; set; }
        public float? Paidmm { get; set; }
        public float? PaidClient { get; set; }
        public float? Interest { get; set; }
        public float? CollectionFee { get; set; }
        public float? AdminCosts { get; set; }
        public bool Closed { get; set; }
        public string DisputeAction { get; set; }
        public DateTime? ActionDate { get; set; }
        public string Action { get; set; }
        public int UploadId { get; set; }
        public int DebtorId { get; set; }
        public int? AdministratorId { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? UserId { get; set; }
        public string Paractitioner { get; set; }
        public int? Status { get; set; }

        public virtual Administrators Administrator { get; set; }
        public virtual Debtors Debtor { get; set; }
        public virtual StatusCatalogs StatusNavigation { get; set; }
        public virtual Uploads Upload { get; set; }
        public virtual AbpUsers User { get; set; }
        public virtual ICollection<InvoiceNotes> InvoiceNotes { get; set; }
    }
}
