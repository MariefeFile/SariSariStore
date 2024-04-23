using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Services
{
    internal class DatabaseService
    {
        private const string ConnectionPath = "C:\\Users\\Nivanz Aricayos\\Documents\\Codes\\Projects\\SariSariStore\\store.mdb";

        public bool IsDatabaseConnected()
        {
            try
            {
                using (OleDbConnection myConn = new OleDbConnection($"Provider=Microsoft.JET.OLEDB.4.0;Data Source={ConnectionPath}"))
                {
                    myConn.Open();
                    myConn.Close();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
