using MobileFront.Views;

namespace MobileFront;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        MainPage = new NavigationPage(new HomePage());
    }
}
