using Caesar.Data;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Caesar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewRecipePage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public Recipe Recipe { get; set; }

        public ViewRecipePage(Recipe recipe = null)
        {
            InitializeComponent();
            Recipe = recipe;

            RecipeLayout.BindingContext = Recipe;
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            _ = Launcher.OpenAsync(new Uri(Recipe.Url));
        }
    }
}