using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Infrastructure.Interfaces;
using ShoppingListApp.Infrastructure.Models;
using ShoppingListApp.ViewModels;

namespace ShoppingListApp.Controllers
{
    public class ShoppingListController : Controller
    {
        private IShoppingListRepository shoppingItemRepository;

        public ShoppingListController(IShoppingListRepository shoppingItemRepository)
        {
            this.shoppingItemRepository = shoppingItemRepository;
        }

        public IActionResult List()
        {
            ShoppingListViewModel vm = new ShoppingListViewModel();
            vm.ShoppingItemRepository = shoppingItemRepository;
            return View("List", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddShoppingItem(ShoppingListViewModel shoppingItemVM)
        {
            if (ModelState.IsValid)
            {
                shoppingItemRepository.AddShoppingItem(shoppingItemVM.NewItemName, shoppingItemVM.NewItemShop);
                ModelState.Clear();
            }

            return List();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteShoppingItem(int itemID)
        {
            shoppingItemRepository.DeleteShoppingItem(itemID);
            return List();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleUrgent(int itemID)
        {
            shoppingItemRepository.ToggleUrgent(itemID);
            return List();
        }
    }
}