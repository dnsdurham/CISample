using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CISample.DatabaseUpdater.Managers
{
    public interface IDBUpdaterManager
    {
        void RunMigration(string databaseName);
    }

    class DBUpdaterManager : IDBUpdaterManager
    {
        public void RunMigration(string databaseName)
        {
            // TODO: Add some logging here as appropriate
            // Add some console writes that are picked up by TeamCity, etc
            Console.WriteLine("##teamcity[message text='Performing DB Migrations']");

            // get the database connection string info using the databaseName parameter
            string connString = @"User Id=xxx; Password=yyy; Data Source=zzz; Pooling=false";


        }
    }
}
