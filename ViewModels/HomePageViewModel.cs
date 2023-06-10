using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileFront.Models;
using MobileFront.Models.DTOs;
using MobileFront.Services;
using MobileFront.Views;

namespace MobileFront.ViewModels
{
    /// <summary>
    /// View model for the HomePage
    /// </summary>
    public partial class HomePageViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets the list of assets.
        /// </summary>
        public List<AssetDTO> Assets { get; } = new();

        /// <summary>
        /// Gets or sets the selected asset
        /// </summary>
        [ObservableProperty]
        Asset selectedAsset;

        /// <summary>
        /// Gets or sets a value indicating whether the view is refreshing
        /// </summary>
        [ObservableProperty]
        bool isRefreshing;

        private IAssetsServices _assetsServices;
        private IConnectivity _connectivity;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageViewModel"/> class
        /// </summary>
        /// <param name="assetsServices">The assets services</param>
        /// <param name="connectivity">The connectivity NetworkAccess service</param>
        public HomePageViewModel(IAssetsServices assetsServices, IConnectivity connectivity)
        {
            _assetsServices = assetsServices;
            _connectivity = connectivity;
            Title = "Assets list";
        }

        /// <summary>
        /// Recovers the assets after verifying the connection
        /// </summary>
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

                if (assetList != null)
                {
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

        /// <summary>
        /// Navigates to the details view of a selected asset carrying the asset's data
        /// </summary>
        /// <param name="assetparameter">The selected asset</param>
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
