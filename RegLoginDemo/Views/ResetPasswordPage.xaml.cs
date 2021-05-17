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
    public partial class ResetPasswordPage : ContentPage
    {
        public ResetPasswordPage()
        {
            InitializeComponent();
        }
        async void ResetPageButton_Clicked(object sender, EventArgs e)
        {
            if((string.IsNullOrWhiteSpace(resetUserVal.Text)) || (string.IsNullOrEmpty(resetUserVal.Text)) ||
               (string.IsNullOrWhiteSpace(resetOldPassVal.Text)) || (string.IsNullOrEmpty(resetOldPassVal.Text)) ||
               (string.IsNullOrWhiteSpace(resetNewPassVal.Text)) || (string.IsNullOrEmpty(resetNewPassVal.Text)) ||
               (string.IsNullOrWhiteSpace(resetConfirmPassVal.Text)) || (string.IsNullOrEmpty(resetConfirmPassVal.Text))
              )
            {
                await DisplayAlert("Failure", "Enter all data", "OK");
            }
            else
            {
                if(!(resetOldPassVal.Text.Equals(resetNewPassVal.Text)))
                {
                    await DisplayAlert("Failure", "New Password and Confirm Password should be same", "OK");
                }
                else 
                {
                    var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
                    var db = new SQLiteConnection(dbpath);
                    var data = db.Table<RegisteredUsers>();
                    var update = (from values in data where values.Username == resetUserVal.Text select values).Single();
                    if (true)
                    {
                        update.Password = resetNewPassVal.Text;
                        db.Update(update);
                        await DisplayAlert("Success", "New Password updated", "OK");
                        await Navigation.PushAsync(new LoginPage());
                    }
                }
                
            }
        }
    }
}