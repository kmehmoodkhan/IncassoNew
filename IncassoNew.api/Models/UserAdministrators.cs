using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class UserAdministrators
    {
        public long UserId { get; set; }
        public int AdministratorId { get; set; }

        public virtual Administrators Administrator { get; set; }
        public virtual AbpUsers User { get; set; }
    }
}
