using MobileFront.Services;
using MobileFront.ViewModels;

namespace MobileFront.Views;

public partial class HomePage : ContentPage
{
	public HomePage(IAssetsServices assetsServices)
    {
        InitializeComponent();
        BindingContext = new AssetsListViewModel(assetsServices);
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