using Caesar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caesar.Services
{
    public static class RecipeService
    {
        static IList<Recipe> Recipes { get; }

        static RecipeService()
        {
            Recipes = new List<Recipe>
            {
                new Recipe {
                    Id = 1,
                    Name = "PBJ Sandwich", 
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient { Name = "Bread", Quantity = "2 slices" },
                        new Ingredient { Name = "Peanut Butter", Quantity = "2 tablespoons" },
                        new Ingredient { Name = "Jelly", Quantity = "2 tablespoons" }
                    }
                }
            };
        }

        public static IList<Recipe> GetAll() => Recipes;

    }
}
