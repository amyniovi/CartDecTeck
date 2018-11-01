using System;
using System.Collections.Generic;
using System.Linq;
using TDDCart.Models.Calculators.Interfaces;

namespace TDDCart.Models.Calculators
{
    public class CartDiscountCalculator : ICartDiscountCalculator
    {
        public List<ICartDiscountRule> DiscountRules = new List<ICartDiscountRule>();

        public CartDiscountCalculator()
        {
            DiscountRules.Add(new TwoButterRule());
        }

        public decimal CalculateDiscountedTotalPrice(IEnumerable<CartItem> items)
        {
            var cartItems = items as IList<CartItem> ?? items.ToList();
            var total = cartItems.Sum(item => item.TotalItemCost);
            decimal totalDiscount = 0;

            foreach (var rule in DiscountRules)
                if (rule.IsEligible(cartItems))
                {
                    totalDiscount += rule.Discount(cartItems);
                }

            return total - totalDiscount;
        }
    }

    public class TwoButterRule : ICartDiscountRule
    {
        public bool IsEligible(IEnumerable<CartItem> items)
        {
            var cartItems = items as IList<CartItem> ?? items.ToList();
            return cartItems
                       .Any(item => item.Name == "butter" && item.Qty >= 2) && 
                   cartItems
                       .Any(item => item.Name == "bread");
        }

        public decimal Discount(IEnumerable<CartItem> items)
        {
            var cartItems = items as IList<CartItem> ?? items.ToList();
            var butterItem = cartItems
                .FirstOrDefault(item => item.Name == "butter");

            if (butterItem == null)
                return 0m;

            var discountedBreadCount = Math.Floor((decimal)butterItem.Qty) / 2;
            var breadUnitCost = cartItems.First(item => item.Name == "bread").CostPerUnit;
            var discount = discountedBreadCount * breadUnitCost * 0.5m;
            return discount;
        }
    }
}