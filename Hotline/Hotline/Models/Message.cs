﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotline.Models
{
    public class Message
    {
        public string Sender { get; set; }

        public string Text { get; set; }

        public Message(string sender, string text)
        {
            Sender = sender;
            Text = text;
        }
    }
}
