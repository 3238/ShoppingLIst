using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListApp.Infrastructure.Models
{
    public enum Store { Lidl, Colruyt, AlbertHein, Carrefour}

    public class ShoppingItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Store Store { get; set; }
    }
}
