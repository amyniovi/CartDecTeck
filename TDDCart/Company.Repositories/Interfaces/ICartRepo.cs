using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDCart.Models;

namespace TDDCart.Company.Repositories.Interfaces
{
   public interface ICartRepo
   {
       //Here we specify the ID cause we dont have a DB to generate
       Cart Create (string username);
       Cart Update(IEnumerable<CartItem> items);
       Cart Update(CartItem item);

   }
}
