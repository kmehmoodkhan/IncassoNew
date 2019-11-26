using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class Administrators
    {
        public Administrators()
        {
            Debtors = new HashSet<Debtors>();
            Invoices = new HashSet<Invoices>();
            UploadAdministrators = new HashSet<UploadAdministrators>();
            UserAdministrators = new HashSet<UserAdministrators>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Bank { get; set; }
        public string Account { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public string AdminId { get; set; }

        public virtual ICollection<Debtors> Debtors { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<UploadAdministrators> UploadAdministrators { get; set; }
        public virtual ICollection<UserAdministrators> UserAdministrators { get; set; }
    }
}
