using MobileFront.Services;
using MobileFront.ViewModels;

namespace MobileFront.Views;

public partial class HomePage : ContentPage
{
	public HomePage(IAssetsServices assetsServices, IConnectivity connectivity)
    {
        InitializeComponent();
        BindingContext = new AssetsListViewModel(assetsServices, connectivity);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is AssetsListViewModel viewModel)
        {
            viewModel.GetAssetsCommand.Execute(null);
        }
    }
}