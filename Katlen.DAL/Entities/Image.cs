﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageSource { get; set; }
        public Product Product { get; set; }

    }
}
