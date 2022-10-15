using Hotline.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotline.Services
{
    public class MessageService : DatabaseService, IMessageService
    {
        public void Add(Message user)
        {
            throw new NotImplementedException();
        }

        public void Edit(Message user)
        {
            throw new NotImplementedException();
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAll()
        {
            if (!Connect())
            {
                return null;
            }

            MySqlCommand command = new()
            {
                Connection = Connection,
                CommandText = "SELECT * FROM messages"
            };

            MySqlDataReader reader = command.ExecuteReader();
            List<Message> messages = new();

            while (reader.Read())
            {
                messages.Add(new Message(reader[1].ToString(), reader[2].ToString()));
            }

            if (messages.Count == 0)
            {
                Disconnect();

                return null;
            }

            Disconnect();

            return messages;
        }
    }
}
