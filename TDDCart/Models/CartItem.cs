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

        public decimal GetTotalDiscountedCost()
        {
            //for now no rules implemented
            return Qty * CostPerUnit;
        }
    }
}