using store.Constants;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.Repositories
{
    internal class DatabaseRepository
    {
        public bool IsDatabaseConnected()
        {
            try
            {
                using (OleDbConnection myConn = new OleDbConnection(Data.ConnectionString))
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
