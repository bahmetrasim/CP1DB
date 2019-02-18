using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using System.Threading.Tasks;
using CP1.Droid;
using System.IO;

[assembly: Dependency(typeof(Database_android))]
namespace CP1.Droid
{

    public class Database_android : ILocalFile
    {
        async Task<SQLiteAsyncConnection> ILocalFile.GetConnection()
        {
            string databaseName = "MPT.db3";
            var docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbFile = Path.Combine(docFolder, databaseName);

            if (!File.Exists(dbFile))
            {
                FileStream writeStream = new FileStream(dbFile, FileMode.OpenOrCreate, FileAccess.Write);
#pragma warning disable CS0618 // Type or member is obsolete
                await Forms.Context.Assets.Open(databaseName).CopyToAsync(writeStream);
#pragma warning restore CS0618 // Type or member is obsolete

            }
            var path = dbFile;
            var conn = new SQLiteAsyncConnection(path);
            return conn;

        }
    }
}