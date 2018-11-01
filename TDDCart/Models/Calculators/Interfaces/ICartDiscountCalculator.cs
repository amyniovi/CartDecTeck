using System.Collections.Generic;

namespace TDDCart.Models.Calculators.Interfaces
{
    public interface ICartDiscountCalculator
    {
        decimal CalculateDiscountedTotalPrice(IEnumerable<CartItem> items);
    }
}