using Katlen.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katlen.BLL.Interfaces
{
    public interface ICardProduct
    {
        public CardProductDTO GetCardProductById(int id);
    }
}
