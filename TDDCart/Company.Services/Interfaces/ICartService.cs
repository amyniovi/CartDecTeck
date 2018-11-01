using System.Collections.Generic;
using TDDCart.Models;

namespace TDDCart.Company.Services.Interfaces
{
    public interface ICartService
    {
        Cart AddItems(IEnumerable<CartItem> items, Cart cart);
    }
}
