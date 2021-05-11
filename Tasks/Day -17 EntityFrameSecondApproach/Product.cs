﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameSecondApproach
{
    public class Product
    {
        [Key]
          
        public int ProductId { get; set;}

        public string ProductName { get; set; }

        public int Price { get; set; }

        public int Quality { get; set; }

    }
}
