//using Caesar.Data;
using Caesar.Data;
using Caesar.Pages;
using Caesar.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;

namespace Caesar
{
    public partial class SearchPage : ContentPage
    {
        public IList<Data.Recipe> recipes = new ObservableCollection<Data.Recipe>();

        public SearchPage()
        {
            BindingContext = recipes;
            InitializeComponent();
        }

        async void OnViewRecipe(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new ViewRecipePage((Data.Recipe)e.Item)));
        }

        async void CreateRecipe(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new CreateRecipePage()));
        }

        public async void SearchRecipes(object sender, EventArgs e)
        {
            string input = ingredientsEntry.Text;

            // User input check
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            input = input.ToLower();
            string[] parsedInput = input.Split(',').Select(i => i.Trim()).ToArray();

            string inputString = string.Join("%20", parsedInput);

            // Get rid of the leading %20
            inputString.Remove(0, 2);

            HttpRequestService service = new HttpRequestService();

            var body = await service.RecipeRequest(inputString);

            RecipeResponse recipeResponse = JsonConvert.DeserializeObject<RecipeResponse>(body);

            // Reset the recipes collection for each search
            recipes.Clear();

            foreach (var recipe in recipeResponse.Hits)
            {
                recipes.Add(recipe.Recipe);
            }

        }
    }



}
