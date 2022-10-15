using Hotline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hotline.Services
{
    public interface IMessageService
    {
        void Add(Message user);

        void Edit(Message user);

        void RemoveById(int id);

        Message GetById(int id);

        IEnumerable<Message> GetAll();
    }
}
