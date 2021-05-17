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
    public partial class DeleteAccountPage : ContentPage
    {
        public DeleteAccountPage()
        {
            InitializeComponent();
        }
        async void DeleteAccButton_Clicked(object sender,EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(usernametoDelete.Text)) || (string.IsNullOrEmpty(usernametoDelete.Text)) ||
               (string.IsNullOrWhiteSpace(passwordtoDelete.Text)) || (string.IsNullOrEmpty(passwordtoDelete.Text))
             )
            {
                await DisplayAlert("Enter Data", "Enter Valid Data To Delete", "OK");
            }
            else
            {
                var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
                var db = new SQLiteConnection(dbpath);
                var del = db.Table<RegisteredUsers>().Where(u => u.Username.Equals(usernametoDelete.Text) && u.Password.Equals(passwordtoDelete.Text)).FirstOrDefault();
                if(del != null)
                {
                    db.Delete<RegisteredUsers>(del.Username);
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    await DisplayAlert("Failure", "Account Not Found", "OK");
                }
            }
        }
    }
}