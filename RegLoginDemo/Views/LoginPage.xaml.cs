using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using RegLoginDemo.Tables;

namespace RegLoginDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }

        async void SignUpButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
        async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteAccountPage());
        }
        async void ResetButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResetPasswordPage());
        }
        async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if((string.IsNullOrWhiteSpace(usernameVal.Text)) || (string.IsNullOrEmpty(usernameVal.Text)) ||
                (string.IsNullOrWhiteSpace(passwordVal.Text)) || (string.IsNullOrEmpty(passwordVal.Text))
              )
            {
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
            }
            else
            {
                var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
                var db = new SQLiteConnection(dbpath);
                var fetch = db.Table<RegisteredUsers>().Where(u => u.Username.Equals(usernameVal.Text) && u.Password.Equals(passwordVal.Text)).FirstOrDefault();
                if (fetch != null)
                {
                    string s = usernameVal.Text;
                    App.Current.MainPage = new NavigationPage(new HomePage(s));
                }
                else
                {
                    //await this.DisplayAlert("Failure", "Invalid Username or Password", "Yes", "Cancel");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var res = await this.DisplayAlert("Failure", "Invalid Username or Password", "Yes", "Cancel");
                        if (res)
                        {
                            
                            await Navigation.PushAsync(new LoginPage());
                        }
                        else
                        {
                            await Navigation.PushAsync(new LoginPage());
                        }

                    });
                }
            }     
        }
    }
}