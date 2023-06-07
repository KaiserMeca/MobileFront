using MobileFront.ViewModels;

namespace MobileFront.Views;

public partial class HomePage : ContentPage
{
	public HomePage(AssetsListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}