using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caesar.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
    }
}
