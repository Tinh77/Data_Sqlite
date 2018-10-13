using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContact.Entity
{
    class ContactAccess
    {
        public static string SQLITE_CONNECTION = "Filename=sqliteSample.db";
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection(SQLITE_CONNECTION))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Contacts (phone NVARCHAR(50) PRIMARY KEY, " +
                    "name NVARCHAR(28) NULL, email NVARCHAR(28) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }
    }
}
