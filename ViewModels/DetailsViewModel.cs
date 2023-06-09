using CommunityToolkit.Mvvm.ComponentModel;
using MobileFront.Models;
using MobileFront.Models.DTOs;

namespace MobileFront.ViewModels
{
    [QueryProperty(nameof(Asset), "assetKey")]
    public partial class DetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        AssetDTO asset;
        public DetailsViewModel()
        {
        }
    }
}
