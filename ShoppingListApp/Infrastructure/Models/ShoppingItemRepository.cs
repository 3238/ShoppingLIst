using ShoppingListApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListApp.Infrastructure.Models
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        private readonly AppDbContext appDbContext;

        public ShoppingItemRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<ShoppingItem> ShoppingItems => appDbContext.ShoppingItems;

        public ShoppingItem GetByID(int id)
        {
            return appDbContext.ShoppingItems.FirstOrDefault(si => si.ID == id);
        }
    }
}
