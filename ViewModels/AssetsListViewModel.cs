using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileFront.Models;
using MobileFront.Services;
using System.Collections.ObjectModel;

namespace MobileFront.ViewModels
{
    public partial class AssetsListViewModel : BaseViewModel
    {
        public ObservableCollection<Asset> Assets { get; } = new();
        [ObservableProperty]
        Asset selectedAsset;
        [ObservableProperty]
        bool isRefreshing;

        IAssetsServices _assetsServices;

        public AssetsListViewModel(IAssetsServices assetsServices)
        {
            _assetsServices = assetsServices;
        }

        public AssetsListViewModel()
        {
        }

        [RelayCommand]
        public async Task GetAssets()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var assetList = await _assetsServices.SeeList();
                if (assetList != null)
                {
                    foreach (var item in assetList)
                    {
                        Assets.Add(item);
                        Title = "Assets list";
                    }
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
        async Task goToDetailsAsync()
        {
            if (selectedAsset == null)
            {
                return;
            }
            var data = new Dictionary<string, object>
            {
                { "asset", selectedAsset }


            };
            //await Shell.Current.GoToAsync(page, true, data);
        }

        //Agregar el goToDetails

    }
}
