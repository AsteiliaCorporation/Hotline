using Hotline.Views;

namespace Hotline;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ChatPage), typeof(ChatPage));
	}
}
