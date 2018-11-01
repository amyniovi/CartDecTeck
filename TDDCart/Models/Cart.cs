using System.Collections.Generic;
using TDDCart.Company.Interfaces;

namespace TDDCart.Models
{
    public class Cart
    {
        private readonly IDiscountCalculator _discountCalculator;
        private IEnumerable<CartItem> _items;

        public Cart(IDiscountCalculator discountCalculator)
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
        public decimal TotalCost => _discountCalculator.CalculateTotalCost();

        private void TryAddItems(IEnumerable<CartItem> items)
        {

        }
    }
}