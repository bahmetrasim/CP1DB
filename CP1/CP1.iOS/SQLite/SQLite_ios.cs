using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CP1.iOS.SQLite;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_ios))]
namespace CP1.iOS.SQLite
{
    public class SQLite_ios : ISQLite
    {
        public async Task<SQLiteConnection> ISQLite.GetConnection()
        {
            String databasename = "MTP.db3";
            var documentpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentpath,, databasename);

            if (!File.Exists(path))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("MyLite", "db3");
            }

            var path = dbfile;
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}