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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        async void RegButton_Clicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(userNameValue.Text)) || (string.IsNullOrEmpty(userNameValue.Text)) ||
                (string.IsNullOrWhiteSpace(PasswordValue.Text)) || (string.IsNullOrEmpty(PasswordValue.Text)) ||
                (string.IsNullOrWhiteSpace(EmailValue.Text)) || (string.IsNullOrEmpty(EmailValue.Text)) ||
                (string.IsNullOrWhiteSpace(PhoneNumberValue.Text)) || (string.IsNullOrEmpty(PhoneNumberValue.Text))
              )
            {
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
            }
            else
            {
                var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
                var db = new SQLiteConnection(dbpath);
                db.CreateTable<RegisteredUsers>();
                var user_det = new RegisteredUsers()
                {
                    Username = userNameValue.Text,
                    Password = PasswordValue.Text,
                    EmailId = EmailValue.Text,
                    PhoneNumber = PhoneNumberValue.Text
                };

                db.Insert(user_det);
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var res = await this.DisplayAlert("Congrats", "User Details Registered Successfully", "Yes", "Cancel");
                    if (res)
                    {
                        await Navigation.PushAsync(new LoginPage());
                    }

                });
            }
        }
    }
}