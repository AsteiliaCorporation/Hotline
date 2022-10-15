using CommunityToolkit.Mvvm.Input;
using Hotline.Models;
using Hotline.Services;
using Hotline.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotline.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        public MainViewModel(MessageService userService)
        {
            Title = "Hotline";
            MessageService = userService;
            GetMessagesAsync();
        }

        [RelayCommand]
        private async Task GoToChat(Message message)
        {
            if (message is null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(ChatPage)}?id={message.Sender}", true,
                new Dictionary<string, object>
                {
                    {"Message", message}
                });
        }

        public async Task GetMessagesAsync()
        {
            if (IsBusy)
            {
                return;
            }

            Messages = new(MessageService.GetAll());
        }

        public MessageService MessageService { get; set; }

        public ObservableCollection<Message> Messages { get; private set; }
    }
}
