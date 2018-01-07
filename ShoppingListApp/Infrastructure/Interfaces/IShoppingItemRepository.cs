using ShoppingListApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListApp.Infrastructure.Interfaces
{
    public interface IShoppingItemRepository
    {
        IEnumerable<ShoppingItem> ShoppingItems { get; }

        ShoppingItem GetByID(int id);
    }
}
