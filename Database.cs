using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace ASP_crudBootstrap
{
    public class Database
    {
        MySqlConnection connection;
        MySqlCommand cmd;
        MySqlDataReader datareader;

        public Database(string server, string id, string db_name)
        {
            connection = new MySqlConnection();
            connection.ConnectionString = "server=" + server + "; user id=" + id + ";database=" + db_name + "; password= ;convert zero datetime=true";
        }
        public void OpenDatabase()
        {
            connection.Open();
        }
        public void CloseDatabase()
        {
            connection.Close();
        }
        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void Insert(string name, string address, DateTime dob, string gender, string civilstat, string filename)
        {
            cmd = new MySqlCommand("insert into simpledb" + "(name,address,dob,gender,civilstat,filename)"
                + "values (@name,@address,@dob,@gender,@civilstat,@filename)", connection);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("address", address);
            cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@civilstat", civilstat);
            cmd.Parameters.AddWithValue("@filename", filename);

            cmd.ExecuteNonQuery();

        }

        public MySqlDataReader Search(string name)
        {
            cmd = new MySqlCommand("(select * from simpledb where name='" + name + "');", connection);
            datareader = cmd.ExecuteReader();            
            return datareader;

        }

        public void Edit(string name, string address, string dob, string gender, string civilstat, string filename)
        {
            cmd = new MySqlCommand("update simpledb set name='" + name + "', address='" + address + "', dob='" + dob
                + "', gender='" + gender + "', civilstat='" + civilstat + "', filename='" + filename + "' where name='" + name + "';", connection);

            cmd.ExecuteNonQuery();

        }

        public void Delete(string name)
        {
            cmd = new MySqlCommand("delete from simpledb where name='" + name + "';", connection);

            cmd.ExecuteNonQuery();
        }

        public MySqlDataReader getAll()
        {
            MySqlCommand cmd = new MySqlCommand("select * from simpledb", connection);
            datareader = cmd.ExecuteReader();
            return datareader;
        }



    }
}