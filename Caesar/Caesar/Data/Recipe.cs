using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Caesar.Data
{
    // Primary result from the query
    public class RecipeResponse
    {
        [JsonPropertyName("hits")]
        public IEnumerable<Result> Hits { get; set; }
    }

    // Need this because the currently used API has an array between the results and the recipes
    public class Result
    {
        public Recipe Recipe { get; set; }
    }

    public class Recipe
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ingredients")]
        public List<Ingredients> Ingredients { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("ingredientLines")]
        public List<string> IngredientLines { get; set; }
        
    }

    public class Ingredients
    {
        public string Ingredient { get; set; }
    }
}
