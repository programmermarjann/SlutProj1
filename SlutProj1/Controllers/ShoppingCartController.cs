using Microsoft.AspNetCore.Mvc;
using SlutProj1.Models;
using SlutProj1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlutProj1.Controllers
{
   
    public class ShoppingCartController : Controller
    {
        private readonly ITshirtRepository _tshirtRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ITshirtRepository tshirtRepository, ShoppingCart shoppingCart)
        {
        _tshirtRepository = tshirtRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int tshirtId)
        {
            var selectedTshirt = _tshirtRepository.AllTshirts.FirstOrDefault(p => p.TshirtID == tshirtId);

            if (selectedTshirt != null)
            {
                _shoppingCart.AddToCart(selectedTshirt, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int tshirtId)
        {
            var selectedTshirt = _tshirtRepository.AllTshirts.FirstOrDefault(p => p.TshirtID == tshirtId);

            if (selectedTshirt != null)
            {
                _shoppingCart.RemoveFromCart(selectedTshirt);
            }
            return RedirectToAction("Index");
        }
    }
}

