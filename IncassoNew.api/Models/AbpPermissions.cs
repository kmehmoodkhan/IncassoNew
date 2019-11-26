using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class AbpPermissions
    {
        public long Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public bool IsGranted { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? UserId { get; set; }
        public int? RoleId { get; set; }
        public string Discriminator { get; set; }

        public virtual AbpRoles Role { get; set; }
        public virtual AbpUsers User { get; set; }
    }
}
