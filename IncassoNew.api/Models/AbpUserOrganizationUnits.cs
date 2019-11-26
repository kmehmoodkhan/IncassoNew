using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class AbpUserOrganizationUnits
    {
        public long Id { get; set; }
        public int? TenantId { get; set; }
        public long UserId { get; set; }
        public long OrganizationUnitId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
    }
}
