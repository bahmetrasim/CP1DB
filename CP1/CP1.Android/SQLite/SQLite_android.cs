using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.Threading.Tasks;
using System.IO;
using CP1.Droid.SQLite;
using Foundation;

[assembly: Dependency(typeof(SQLite_android))]
namespace CP1.Droid.SQLite
{
    public class SQLite_android : ISQLite
    {
        async Task<SQLiteConnection> ISQLite.GetConnection()
        {
            String databasename = "MTP_A.db3";
            var docfolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbfile = Path.Combine(docfolder, databasename);

            if (!File.Exists(dbfile))
            {
                FileStream writestream = new FileStream(dbfile, FileMode.OpenOrCreate, FileAccess.Write);
#pragma warning disable CS0618 // Tür veya üye eski
                await Forms.Context.Assets.Open(databasename).CopyToAsync(writestream);
#pragma warning restore CS0618 // Tür veya üye eski
            }

            var path = dbfile;
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}