﻿using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class AbpSettings
    {
        public long Id { get; set; }
        public int? TenantId { get; set; }
        public long? UserId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }

        public virtual AbpUsers User { get; set; }
    }
}
