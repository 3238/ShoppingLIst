using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Infrastructure.Interfaces;

namespace ShoppingListApp.Controllers
{
    public class ShoppingItemController : Controller
    {
        private IShoppingItemRepository shoppingITemRepository;

        public ShoppingItemController(IShoppingItemRepository shoppingItemRepository)
        {
            shoppingITemRepository = shoppingItemRepository;
        }

        public IActionResult List()
        {
            return View(shoppingITemRepository);
        }

        //[HttpPost]
        //public bool AddShoppingItem(string item)
        //{
        //    AppDb
        //}
    }
}