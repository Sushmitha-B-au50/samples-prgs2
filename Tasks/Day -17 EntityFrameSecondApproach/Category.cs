﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameSecondApproach
{
    class Category
    {
        [Key]
        public int CId { get; set; }

        public string CName { get; set; }

    }
}
