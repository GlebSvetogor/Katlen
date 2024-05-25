using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.DAL.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductSeason> ProductSeasons { get; set; }

    }
}
