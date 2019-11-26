using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class UploadAdministrators
    {
        public int UploadId { get; set; }
        public int AdministratorId { get; set; }

        public virtual Administrators Administrator { get; set; }
        public virtual Uploads Upload { get; set; }
    }
}
