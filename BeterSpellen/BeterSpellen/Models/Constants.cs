using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BeterSpellen.Models
{
    public static class Constants
    {
        public const string databaseName = "Vragen.db3";

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, databaseName);
            }
        }
    }
}
