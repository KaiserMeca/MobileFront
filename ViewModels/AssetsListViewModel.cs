using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileFront.Models;
using MobileFront.Models.DTOs;
using MobileFront.Services;
using MobileFront.Views;

namespace MobileFront.ViewModels
{
    public partial class AssetsListViewModel : BaseViewModel
    {
        public List<AssetDTO> Assets { get; } = new();
        [ObservableProperty]
        Asset selectedAsset;
        [ObservableProperty]
        bool isRefreshing;

        IAssetsServices _assetsServices;
        IConnectivity _connectivity;

        public AssetsListViewModel(IAssetsServices assetsServices, IConnectivity connectivity)
        {
            _assetsServices = assetsServices;
            _connectivity = connectivity;
            Title = "Assets list";
        }

        [RelayCommand]
        public async Task GetAssets()
        {
            if (IsBusy)
                return;
            Assets.Clear();
            try
            {
                IsBusy = true;

                var assetList = (_connectivity.NetworkAccess == NetworkAccess.Internet)
                    ? await _assetsServices.GetAssetsAsync()
                    : await _assetsServices.GetAssetOffLineAsync();
                //var assetList = await _assetsServices.GetAssetsAsync();

                if (assetList != null)
                {
                    //foreach (var item in assetList)
                    //{
                    //    Assets.Add(item);
                    //}
                    Assets.AddRange(assetList);
                }
                if (!assetList.Any())
                {
                    Title = "Empty list";
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
        public async Task GotoDetailsAsync(AssetDTO assetparameter)
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
