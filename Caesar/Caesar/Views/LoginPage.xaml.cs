using Caesar.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Caesar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            // clear any update text from previous attempts
            loginLabel.Text = string.Empty;

            User user = new User()
            {
                Email = emailEntry.Text,
                Password = passwordEntry.Text
            };

            bool isValid = ValidateUser(user);
            if (isValid)
            {
                loginLabel.Text = "Signing in...";
                Navigation.InsertPageBefore(new SearchPage(), this);
                _ = await Navigation.PopAsync();
            }
            else
            {
                loginLabel.Text = "Invalid login information";
                passwordEntry.Text = string.Empty;
            }
        }

        private bool ValidateUser(User user)
        {
            // TODO: send to backend and verify
            return !(string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password));
        }
    }
}