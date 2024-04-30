using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Constants
{
    internal class Data
    {
        public static readonly string ConnectionPath = "C:\\My Calculator Project\\store\\store.mdb";
        public static readonly string ConnectionString = $"Provider=Microsoft.JET.OLEDB.4.0;Data Source={Data.ConnectionPath}";
    }
}
