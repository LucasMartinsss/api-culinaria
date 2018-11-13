using culinariaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace culinariaAPI.Services
{
    public class RecipeService
    {
        public static List<Recipe> recipes { get; set; }
        public static List<Ingredient> ingredients { get; set; }
        public static List<Preparation> preparations { get; set; }
        
    }
}
