using System;
using System.Collections.Generic;

namespace TDDCart.Models
{
    public class CartItem
    {
        public string Name { get; set; }
        public int Qty { get; set; }
        public decimal CostPerUnit { get; set; }

        public decimal TotalItemCost
        {
            get => GetTotalDiscountedCost();
        }

        private decimal GetTotalDiscountedCost()
        {
            var total = CostPerUnit * Qty;

            foreach (var rule in DiscountRules)
            {
                if (rule.Key == this.Name)
                    return rule.Value(this.Qty, CostPerUnit);
            }

            return total;
        }

        public Dictionary<string, Func<int, decimal, decimal>> DiscountRules { get; set; } = new Dictionary<string, Func<int, decimal, decimal>>();

        public CartItem()
        {
            DiscountRules.Add("milk", (qty, costPerUnit) =>
            {
                var total = qty * costPerUnit;
                var discount = Math.Floor(total / 4) * costPerUnit;
                return total - discount;
            });
        }
    }
}