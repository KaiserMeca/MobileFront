using MobileFront.Views;

namespace MobileFront;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Details), typeof(Details));
    }
}
