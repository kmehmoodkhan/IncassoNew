using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class AbpEditions
    {
        public AbpEditions()
        {
            AbpFeatures = new HashSet<AbpFeatures>();
            AbpTenants = new HashSet<AbpTenants>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }

        public virtual ICollection<AbpFeatures> AbpFeatures { get; set; }
        public virtual ICollection<AbpTenants> AbpTenants { get; set; }
    }
}
