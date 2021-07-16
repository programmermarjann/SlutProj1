using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlutProj1.Models
{
    public class ShoppingCart
    {
        private readonly SlutDbContext _appDbContext;

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItems> ShoppingCartItems { get; set; }

        private ShoppingCart(SlutDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<SlutDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();       // Checking if there is a open shopping cart already

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Tshirt tshirt, int amount)  // goes without saying
        {
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Tshirt.TshirtID == tshirt.TshirtID && s.ShoppingCartID == ShoppingCartId);

            if (shoppingCartItem == null)           // if shopping cart is empty it creates a new one
            {
                shoppingCartItem = new ShoppingCartItems
                {
                    ShoppingCartID = ShoppingCartId,
                    Tshirt = tshirt,
                    Amount = 1
                };

                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Tshirt tshirt)        // again
        {
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Tshirt.TshirtID == tshirt.TshirtID && s.ShoppingCartID == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItems> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartID == ShoppingCartId)
                           .Include(s => s.Tshirt)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartID == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }

        public double GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartID == ShoppingCartId)
                .Select(c => c.Tshirt.Price * c.Amount).Sum();
            return total;
        }

    }
}
