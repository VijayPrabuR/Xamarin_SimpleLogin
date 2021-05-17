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
    public partial class HomePage : ContentPage
    {
        public HomePage(string s)
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            /*var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var data = db.Table<RegisteredUsers>().Where(a => a.Username == ).FirstOrDefault();*/
            usr.Text = s;
        }
        async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}