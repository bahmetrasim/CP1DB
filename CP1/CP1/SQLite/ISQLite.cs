﻿using Android.App;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace CP1
{
    public interface ISQLite
    {
        Task<SQLiteConnection> GetConnection();
    }
  
}
