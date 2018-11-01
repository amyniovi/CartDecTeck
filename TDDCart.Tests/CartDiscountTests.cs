using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit;
using NUnit.Framework;
using TDDCart.Company.Interfaces;
using TDDCart.Company.Repositories.Interfaces;
using TDDCart.Company.Services.Interfaces;
using TDDCart.Models;

/*
 *Scenarios
• Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total
should be £2.95
• Given the basket has 2 butter and 2 bread when I total the basket then the total should be
£3.10
• Given the basket has 4 milk when I total the basket then the total should be £3.45
• Given the basket has 2 butter, 1 bread and 8 milk when I total the basket then the total
should be £9.00  *
 */
 /*Comments*/
/*
 * Ideally Repositories should be generic and usually the async method versions are used with an ORM.
 *
 */
namespace TDDCart.Tests
{
    public class CartDiscountTests
    {
        private const string _usernameUniqueId = "amy";

        [TestCase(1,1,1,2.95)]
        public void CartGetTotal_Given1OfEach_ReturnTwoNinetyFive(int breadQty, int butterQty, int milkQty, decimal cartTotal)
        {
            //CreateCart
            var cart = SetUpCart(breadQty, butterQty, milkQty);

            Assert.AreEqual(cartTotal, cart.TotalCost);
        }

        private static Cart SetUpCart(int breadQty, int butterQty, int milkQty)
        {
            var cartRepo = new Mock<ICartRepo>();
            var discountCalculator = new Mock<IDiscountCalculator>();
            var itemRepo = new Mock<IItemRepo>();
            var cartService = new Mock<ICartService>();
            var list = GetItems(breadQty, butterQty, milkQty);

            itemRepo
                .Setup(repo => repo.GetAll())
                .Returns(list);
            cartRepo
                .Setup(repo => repo.Create(It.IsAny<string>()))
                .Returns<string>((username) => new Cart(discountCalculator.Object) {UniqueId = username});

            var cart = cartRepo.Object.Create("amy");
            cartService.Object.AddItems(list, cart);
            return cart;
        }

        private static List<CartItem> GetItems(int breadQty, int butterQty, int milkQty)
        {
            var list = new List<CartItem>();
            list.Add(new CartItem() {Name = "bread", Qty = breadQty});
            list.Add(new CartItem() {Name = "butter", Qty = butterQty});
            list.Add(new CartItem() {Name = "milk", Qty = milkQty});
            return list;
        }
    }
}
