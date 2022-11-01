using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNTPProject.Model
{
    public class DatabaseHandler
    {
        public SQLiteConnection MyConnection;

        public DatabaseHandler()
        {
            MyConnection = new SQLiteConnection("Data Source=NNTPDatabase.sqlite3");
            if (!File.Exists("./NNTPDatabase.sqlite3"))
            {
                SQLiteConnection.CreateFile("NNTPDatabase.sqlite3");
                Debug.WriteLine("Database file created");
            }
            CreateTables();
            
        }

        public void OpenConnection()
        {
            if (MyConnection.State != System.Data.ConnectionState.Open)
            {
                MyConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (MyConnection.State != System.Data.ConnectionState.Closed)
            {
                MyConnection.Close();
            }
        }

        public void CreateTables()
        {
            string query1 = "CREATE TABLE IF NOT EXISTS AllGroups (ID INTEGER PRIMARY KEY, Name TEXT, StartIndex TEXT, EndIndex TEXT)";
            SQLiteCommand myCommand1 = new SQLiteCommand(query1, MyConnection);
            string query2 = "CREATE TABLE IF NOT EXISTS FavouriteGroups (ID INTEGER)";
            SQLiteCommand myCommand2 = new SQLiteCommand(query2, MyConnection);
            OpenConnection();
            myCommand1.ExecuteNonQuery();
            myCommand2.ExecuteNonQuery();   
            CloseConnection();
        }

        public List<DBGroupEntry> GetAllGroups()
        {
            List<DBGroupEntry> AllGroups = new List<DBGroupEntry>();
            string query = "SELECT * FROM AllGroups";
            SQLiteCommand myCommand = new SQLiteCommand(query, MyConnection);
            OpenConnection();
            SQLiteDataReader returnedRow = myCommand.ExecuteReader();
            if (returnedRow.HasRows)
            {
                while (returnedRow.Read())
                {
                    //Debug.WriteLine("Name: {0} || StartIndex: {1} || EndIndex: {2}", returnedRow["Name"], returnedRow["StartIndex"], returnedRow["EndIndex"]);
                    DBGroupEntry Entry = new DBGroupEntry(int.Parse(returnedRow["ID"].ToString()), returnedRow["Name"].ToString(), returnedRow["StartIndex"].ToString(), returnedRow["EndIndex"].ToString());
                    AllGroups.Add(Entry);
                }
            }
            return AllGroups;
        }

        public List<DBGroupEntry> GetAllFavouriteGroups()
        {
            List<DBGroupEntry> ReturnedList = new List<DBGroupEntry>();
            string query = "SELECT FavouriteGroups.ID, AllGroups.Name, AllGroups.StartIndex, AllGroups.EndIndex FROM FavouriteGroups INNER JOIN AllGroups ON FavouriteGroups.ID = AllGroups.ID";
            SQLiteCommand myCommand = new SQLiteCommand(query, MyConnection);
            OpenConnection();
            SQLiteDataReader returnedRow = myCommand.ExecuteReader();
            if (returnedRow.HasRows)
            {
                while (returnedRow.Read())
                {
                    //Debug.WriteLine("Name: {0} || StartIndex: {1} || EndIndex: {2}", returnedRow["Name"], returnedRow["StartIndex"], returnedRow["EndIndex"]);
                    DBGroupEntry Entry = new DBGroupEntry(int.Parse(returnedRow["ID"].ToString()), returnedRow["Name"].ToString(), returnedRow["StartIndex"].ToString(), returnedRow["EndIndex"].ToString());
                    ReturnedList.Add(Entry);
                }
            }
            CloseConnection();
            return ReturnedList;    
        }

        public List<DBGroupEntry> GetSearchedGroups(string PartOfName)
        {
            PartOfName = PartOfName.Trim();
            List<DBGroupEntry> ReturnedList = new List<DBGroupEntry>();
            
            //string query = "SELECT * FROM AllGroups WHERE Name LIKE '%@string%'";
            string query = "SELECT * FROM AllGroups WHERE Name like '%@string%';";
            SQLiteCommand myCommand = new SQLiteCommand(query, MyConnection);
            myCommand.Parameters.AddWithValue("@string", PartOfName);
            OpenConnection();
            
            SQLiteDataReader returnedRow = myCommand.ExecuteReader();
            if (returnedRow.HasRows)
            {
                while (returnedRow.Read())
                {
                    DBGroupEntry Entry = new DBGroupEntry(int.Parse(returnedRow["ID"].ToString()), returnedRow["Name"].ToString(), returnedRow["StartIndex"].ToString(), returnedRow["EndIndex"].ToString());
                    ReturnedList.Add(Entry);
                }
            }
            else
            {
                Debug.WriteLine("Does not have any rows");
            }
            CloseConnection();
            Debug.WriteLine(ReturnedList.Count);
            return ReturnedList;

        }

        public void ReInsertAllGroups(List<ArticleTitles> ListOfGroups)
        {
            
            //Delete all current entries
            string query = "DELETE FROM AllGroups";
            SQLiteCommand myCommand = new SQLiteCommand(query, MyConnection);
            OpenConnection();
            myCommand.ExecuteNonQuery();
            int counter = 0;
            foreach(ArticleTitles Group in ListOfGroups)
            {
                query = "INSERT INTO AllGroups('Name', 'StartIndex', 'EndIndex') VALUES (@Name, @StartIndex, @EndIndex)";
                myCommand = new SQLiteCommand(query, MyConnection);
                myCommand.Parameters.AddWithValue("@Name", Group.Header);
                myCommand.Parameters.AddWithValue("@StartIndex", Group.StartIndex);
                myCommand.Parameters.AddWithValue("@EndIndex", Group.EndIndex);
                var result = myCommand.ExecuteNonQuery();
                counter++;
                if (counter % 500 == 0)
                {
                    Debug.WriteLine("Counter at {0}", counter);
                }
            }
            CloseConnection();
        }

        public void InsertNewFavouriteGroup(int ID)
        {
            OpenConnection();
            //Delete the entry if it already exists
            string query0 = "DELETE FROM FavouriteGroups where ID = @ID";
            SQLiteCommand myCommand0 = new SQLiteCommand(query0, MyConnection);
            myCommand0.Parameters.AddWithValue("@ID", ID);   
            var result0 = myCommand0.ExecuteNonQuery();
            //Add the entry

            string query1 = "INSERT INTO FavouriteGroups('ID') VALUES(@ID)";
            SQLiteCommand myCommand1 = new SQLiteCommand(query1, MyConnection);
            myCommand1.Parameters.AddWithValue("@ID", ID);            
            var result = myCommand1.ExecuteNonQuery();
            CloseConnection();
        }

        public void DeleteFavouriteEntry(int ID)
        {
            OpenConnection();
            string query = "DELETE FROM FavouriteGroups where ID = @ID";
            SQLiteCommand myCommand = new SQLiteCommand(query, MyConnection);
            myCommand.Parameters.AddWithValue("@ID", ID);
            var result = myCommand.ExecuteNonQuery();
            CloseConnection();
        }

       
    }
}
