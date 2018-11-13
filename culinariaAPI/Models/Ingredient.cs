using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace culinariaAPI.Models
{
    public class Ingredient
    {
        public int id { get; set; }

        public string name { get; set; }

        public string qtd { get; set; }

        public int recipe_id { get; set; }
    }
}
