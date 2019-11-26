using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class AbpUserRoles
    {
        public long Id { get; set; }
        public int? TenantId { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }

        public virtual AbpUsers User { get; set; }
    }
}
