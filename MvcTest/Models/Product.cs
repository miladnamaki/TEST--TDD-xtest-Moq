﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTest.Models
{
    public class Product
    {
        public long  Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set;  }
        public int Price { get; set;  }

    }
}
