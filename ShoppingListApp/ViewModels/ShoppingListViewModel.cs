using ShoppingListApp.Infrastructure.Interfaces;
using ShoppingListApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListApp.ViewModels
{
    public class ShoppingListViewModel
    {
        public IShoppingListRepository ShoppingItemRepository {get;set;}
        [Required(ErrorMessage ="Geef een naam voor het nieuwe item op aub.")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="De naam van het item moet minimum {1} en maximum {2} karakters lang zijn.")]
        [Display(Name="Nieuw item")]
        public string NewItemName { get; set; }
        public Store NewItemShop { get; set; }
    }
}
