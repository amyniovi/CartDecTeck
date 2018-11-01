using System.Collections.Generic;

namespace TDDCart.Models.Calculators.Interfaces
{
    public interface ICartDiscountRule
    {
        bool IsEligible(IEnumerable<CartItem> items);
        decimal Discount(IEnumerable<CartItem> items);
    }
}