using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace culinariaAPI.Models
{
    public class Recipe
    {
        public int id { get; set; }

        public string name { get; set; }

        public int portions { get; set; }

        public string calories { get; set; }

        public string details { get; set; }

        public Preparation preparation { get; set; }

        public List<Ingredient> ingredients { get; set; }

        public string category { get; set; }
    }
}
