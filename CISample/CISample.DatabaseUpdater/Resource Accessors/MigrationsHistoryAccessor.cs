using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace CISample.DatabaseUpdater.ResourceAccessors
{
    public interface IMigrationsHistoryAccessor
    {
        void Initialize(string connString);
    }

    class MigrationsHistoryAccessor : IMigrationsHistoryAccessor  
    {
        public void Initialize(string connString)
        {
            // create the migrations history table if it does not exist

            using (var conn = new OracleConnection(connString))
            {
                try
                {
                    //TODO: put the actual table creations cript in here
                    string tableScript = @"
                        BEGIN
                            SELECT COUNT(*)
                            INTO l_cnt
                            FROM dba_tables
                            WHERE owner = <<table owner>>
                            AND table_name = <<table name>>;
 
                            IF( l_cnt > 0 )
                                THEN
                                EXECUTE IMMEDIATE 'SELECT col1 FROM x' 
                                BULK COLLECT INTO some_collection;
                            ELSE
                                SELECT 'table X does not exist'
                                INTO some_variable
                                FROM dual;
                            END IF;
                        END;";
                    OracleCommand cmd = new OracleCommand(tableScript, conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }
    }
}
