using System.Collections.Generic;
using System.Linq;
using TDDCart.Models.Calculators.Interfaces;

namespace TDDCart.Models
{
    public class Cart
    {
        private readonly ICartDiscountCalculator _discountCalculator;
        private List<CartItem> _items = new List<CartItem>();

        public Cart(ICartDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }
            
        //username 
        public string UniqueId { get; set; }
        public IEnumerable<CartItem> Items
        {
            get => _items;
            set => TryAddItems(value);
        }
        public decimal TotalCost => _discountCalculator.CalculateDiscountedTotalPrice(_items);

        private void TryAddItems(IEnumerable<CartItem> items)
        {

           items.ToList().ForEach(item =>
           {
               var itemFound = _items.FirstOrDefault(cartitem => cartitem.Name == item.Name);
               if (itemFound == null)
                   _items.Add(item);
               else
                   itemFound.Qty += 1;
           });
            var b = this._items;
        }
    }
}