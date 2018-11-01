using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDCart.Models;

namespace TDDCart.Company.Repositories.Interfaces
{
    public interface IItemRepo
    {
      IEnumerable<CartItem> GetAll();
    }
}
