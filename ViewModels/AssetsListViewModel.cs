using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileFront.Models;
using MobileFront.Services;
using MobileFront.Views;

namespace MobileFront.ViewModels
{
    public partial class AssetsListViewModel : BaseViewModel
    {
        public List<Asset> Assets { get; } = new();
        [ObservableProperty]
        Asset selectedAsset;
        [ObservableProperty]
        bool isRefreshing;

        IAssetsServices _assetsServices;

        public AssetsListViewModel(IAssetsServices assetsServices)
        {
            _assetsServices = assetsServices;
        }

        [RelayCommand]
        public async Task GetAssets()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var assetList = await _assetsServices.GetAssetsAsync();
                if (assetList != null)
                {
                    foreach (var item in assetList)
                    {
                        Assets.Add(item);
                    }
                    Title = "Assets list";
                }
            }
            catch (Exception ex)
            {

                await Shell.Current.DisplayAlert("Error", ex.ToString(), "Ok");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
        [RelayCommand]
        public async Task GotoDetailsAsync(Asset assetparameter)
        {
            if (assetparameter == null)
            {
                return;
            }
            var data = new Dictionary<string, object>
            {
                { "assetKey", assetparameter }
            };
            await Shell.Current.GoToAsync(nameof(Details), true, data);
        }

    }
}
