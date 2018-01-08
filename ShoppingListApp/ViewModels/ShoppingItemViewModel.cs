using ShoppingListApp.Infrastructure.Interfaces;
using ShoppingListApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListApp.ViewModels
{
    public class ShoppingListViewModel
    {
        public IShoppingItemRepository ShoppingItemRepository {get;set;}
        public string NewItemName { get; set; }
        public Store NewItemShop { get; set; }
    }
}
