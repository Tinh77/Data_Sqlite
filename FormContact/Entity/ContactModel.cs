using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormContact.Entity
{
    class ContactModel
    {
        public static void AddData(Contact obj)
        {
            using (SqliteConnection db =
                new SqliteConnection(ContactAccess.SQLITE_CONNECTION))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Contacts VALUES (@phone, @name, @email);";
                insertCommand.Parameters.AddWithValue("@phone", obj.Phone);
                insertCommand.Parameters.AddWithValue("@name", obj.Name);
                insertCommand.Parameters.AddWithValue("@email", obj.Email);

                insertCommand.ExecuteReader();

                db.Close();
            }

        }

        public static List<Contact> GetData()
        {
            List<Contact> entries = new List<Contact>();

            using (SqliteConnection db =
                new SqliteConnection(ContactAccess.SQLITE_CONNECTION))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Contacts", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    var contact = new Contact();
                    contact.Name = query["name"].ToString();
                    contact.Phone = query["phone"].ToString();
                    contact.Email = query["email"].ToString();
                    entries.Add(contact);
                }

                db.Close();
            }

            return entries;
        }
    }
}
