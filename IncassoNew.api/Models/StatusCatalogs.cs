﻿using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class StatusCatalogs
    {
        public StatusCatalogs()
        {
            Invoices = new HashSet<Invoices>();
        }

        public int Id { get; set; }
        public string Catalog { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }

        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}