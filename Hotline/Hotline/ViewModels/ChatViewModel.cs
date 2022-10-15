using CommunityToolkit.Mvvm.ComponentModel;
using Hotline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotline.ViewModels
{
    [QueryProperty("Message", "Message")]
    public partial class ChatViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Message _message;
    }
}
