﻿using System;
using System.Collections.Generic;

namespace IncassoNew.api.Models
{
    public partial class Counter
    {
        public string Key { get; set; }
        public int Value { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
