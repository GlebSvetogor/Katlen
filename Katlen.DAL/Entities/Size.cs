﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Entities
{
    public class Size
    {
        public int Id { get; set; }
        public string SizeValue { get; set; }
        public int IsAvailable { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
