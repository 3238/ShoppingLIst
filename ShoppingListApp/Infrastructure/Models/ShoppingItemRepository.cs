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
        
        public string NewItemName { get; set; }

        public ShoppingItemRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<ShoppingItem> ShoppingItems => appDbContext.ShoppingItems;

        public ShoppingItem GetByID(int id)
        {
            return appDbContext.ShoppingItems.FirstOrDefault(si => si.ID == id);
        }
        
        public void AddShoppingItem(string itemName, Store store)//)//
        {
            appDbContext.ShoppingItems.Add( new ShoppingItem() { Name = itemName, Store=store } );
            appDbContext.SaveChanges();
        }

        public void DeleteShoppingItem(int itemID)//)//
        {
            ShoppingItem s = appDbContext.ShoppingItems.FirstOrDefault(si => si.ID == itemID);
            if (s == null)
                throw new ArgumentNullException();
            appDbContext.ShoppingItems.Remove(s);
            appDbContext.SaveChanges();
        }

        public void ToggleUrgent(int itemID)//)//
        {
            ShoppingItem s = appDbContext.ShoppingItems.FirstOrDefault(si => si.ID == itemID);
            if (s == null)
                throw new ArgumentNullException();
            s.Urgent = !s.Urgent;
            appDbContext.SaveChanges();
        }
    }
}
