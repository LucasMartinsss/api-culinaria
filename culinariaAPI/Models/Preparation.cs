using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace culinariaAPI.Models
{
    public class Preparation
    {
        public int id { get; set; }

        public string text { get; set; }

        public int recipe_id { get; set; }
    }
}
