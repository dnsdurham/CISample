using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CISample.DatabaseUpdater
{
    public interface IDBUpdaterManager
    {
        void RunMigration(string databaseName);
    }

    class DBUpdaterManager : IDBUpdaterManager
    {
        public void RunMigration(string databaseName)
        {
            throw new NotImplementedException();
        }
    }
}
