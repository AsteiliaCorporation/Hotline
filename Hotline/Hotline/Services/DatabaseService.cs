using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotline.Services
{
    public class DatabaseService
    {
        private MySqlConnection _connection;

        private readonly string _server = "109.199.240.127";
        private readonly string _database = "hotline";
        private readonly string _username = "userhotline";
        private readonly string _password = "mehmet33";

        public DatabaseService()
        {
            Connection = new MySqlConnection($"SERVER={_server};DATABASE={_database};UID={_username};PASSWORD={_password};SSLMODE=Preferred");
        }

        protected bool Connect()
        {
            try
            {
                Connection.Open();

                return true;
            }
            catch (MySqlException exception)
            {
                switch (exception.Number)
                {
                    case 0:
                        Shell.Current.DisplayAlert($"Error: {exception.Number}", "Cannot connect to server.  Contact administrator", "OK");
                        break;
                    case 1045:
                        Shell.Current.DisplayAlert($"Error: {exception.Number}", "Invalid username/password, please try again", "OK");
                        break;
                    default:
                        Shell.Current.DisplayAlert($"Error: {exception.Number}", "Unknown error!", "OK");
                        break;
                }

                return false;
            }
        }

        protected bool Disconnect()
        {
            try
            {
                Connection.Close();

                return true;
            }
            catch (MySqlException exception)
            {
                Shell.Current.DisplayAlert(exception.Code.ToString(), exception.Message, "OK");

                return false;
            }
        }

        public void Insert(string table, string specificTables, string values)
        {
            string query = $"INSERT INTO {table} ({specificTables}) VALUES({values})";

            if (Connect())
            {
                MySqlCommand command = new(query, Connection);

                command.ExecuteNonQuery();
                Disconnect();
            }
        }

        public void Update()
        {
            string query = $"UPDATE users SET username='Anton Dimitrov', age='16' WHERE name='Suat Alikoch'";

            if (Connect())
            {
                MySqlCommand command = new(query, Connection);

                command.ExecuteNonQuery();
                Disconnect();
            }
        }

        public void Delete()
        {
            string query = $"DELETE FROM users WHERE name='Suat Alikoch'";

            if (Connect())
            {
                MySqlCommand command = new(query, Connection);

                command.ExecuteNonQuery();
                Disconnect();
            }
        }

        public bool Select(string table, string columnItem, string value, string columnItem2, string value2)
        {
            string query = $"SELECT * FROM {table} WHERE {columnItem}='{value}' AND {columnItem2}='{value2}'";

            //- List<string> result = new();

            if (Connect())
            {
                MySqlCommand command = new(query, Connection);

                if (command.ExecuteScalar() == null)
                {
                    return false;
                }

                Disconnect();
            }

            return true;
        }

        public int Count()
        {
            return default;
        }

        public void Backup()
        {

        }

        public void Restore()
        {

        }

        protected MySqlConnection Connection
        {
            get => _connection;
            private set => _connection = value;
        }
    }
}
