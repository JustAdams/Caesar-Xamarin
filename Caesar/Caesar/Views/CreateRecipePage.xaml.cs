using Caesar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Caesar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateRecipePage : ContentPage
    {
        public string RecipeName { get; set; }
        public List<Ingredient> ingredients;

        public CreateRecipePage()
        {
            InitializeComponent();
            ingredients = new List<Ingredient>();
            BindingContext = ingredients;
        }

        public void AddIngredientHandler(object sender, EventArgs e)
        {
            ingredients.Add(new Ingredient { Name = ingredientEntry.Text, Quantity = "One" });
        }

        public void CreateNewRecipe(object sender, EventArgs e)
        {
        }

    }
}