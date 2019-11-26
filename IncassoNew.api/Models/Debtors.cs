using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class Debtors
    {
        public Debtors()
        {
            Invoices = new HashSet<Invoices>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Postal { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public string NotesMm { get; set; }
        public int Status { get; set; }
        public int AdministratorId { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public string DossierNo { get; set; }

        public virtual Administrators Administrator { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}
