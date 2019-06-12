using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xam.FormsPlugin.Abstractions;
using SQLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CP1
{
    public class App : Application
    {
       

        public App()
        {
            MainPage = new NavigationPage(new MainPage());
            //DatabasePath = databasePath;
        }
        //public static AlloyDatabase Database
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database = new AlloyDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MTP.db3"));
        //        }
        //        return database;
        //     }
        //}

        public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
