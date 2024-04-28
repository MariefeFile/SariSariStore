using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Constants
{
    internal class Data
    {
        public static readonly string ConnectionPath = "C:\\Users\\Nivanz Aricayos\\Documents\\Codes\\Projects\\SariSariStore\\store.mdb";
        public static readonly string ConnectionString = $"Provider=Microsoft.JET.OLEDB.4.0;Data Source={Data.ConnectionPath}";
    }
}
