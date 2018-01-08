using ShoppingListApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListApp.Infrastructure.Interfaces
{
    public interface IShoppingListRepository
    {
        IEnumerable<ShoppingItem> ShoppingItems { get; }
        
        void AddShoppingItem( string itemName, Store store);
        void DeleteShoppingItem(int itemID);
        void ToggleUrgent(int itemID);
    }
}
