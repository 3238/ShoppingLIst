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
    public class ShoppingItemController : Controller
    {
        private IShoppingItemRepository shoppingItemRepository;

        public ShoppingItemController(IShoppingItemRepository shoppingItemRepository)
        {
            this.shoppingItemRepository = shoppingItemRepository;
        }

        public IActionResult List()
        {
            ShoppingItemViewModel vm = new ShoppingItemViewModel();
            vm.ShoppingItemRepository = shoppingItemRepository;
            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult AddShoppingItem(ShoppingItemViewModel shoppingItemVM)//string itemName)
        {
            shoppingItemRepository.AddShoppingItem(shoppingItemVM.NewItemName, shoppingItemVM.NewItemShop);// itemName);
            return RedirectToAction("List");
        }

        [HttpPost]
        public RedirectToActionResult DeleteShoppingItem(int itemID)//string itemName)
        {
            shoppingItemRepository.DeleteShoppingItem(itemID);// itemName);
            return RedirectToAction("List");
        }
        
        public RedirectToActionResult ToggleUrgent(int itemID)//string itemName)
        {
            shoppingItemRepository.ToggleUrgent(itemID);// itemName);
            return RedirectToAction("List");
        }
    }
}