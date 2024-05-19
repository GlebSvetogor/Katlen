using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Entities
{
    public class ProductSize
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
        public int IsSizeAvailable { get; set; }
    }
}
