using Hotline.ViewModels;

namespace Hotline.Views;

public partial class ChatPage : ContentPage
{
	public ChatPage(ChatViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}