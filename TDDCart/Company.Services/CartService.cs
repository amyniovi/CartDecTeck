using System.Collections.Generic;
using TDDCart.Company.Repositories.Interfaces;
using TDDCart.Models;

namespace TDDCart.Company.Services
{
    public class CartService
    {
        private ICartRepo _cartRepo;

        public CartService(ICartRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }

        public Cart AddItems(IEnumerable<CartItem> items, Cart cart)
        {
            cart.Items = items;
            _cartRepo.Update(items);
            return cart;
        }
    }
}