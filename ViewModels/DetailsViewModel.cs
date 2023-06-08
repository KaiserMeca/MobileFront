using CommunityToolkit.Mvvm.ComponentModel;
using MobileFront.Models;

namespace MobileFront.ViewModels
{
    [QueryProperty(nameof(Asset), "assetKey")]
    public partial class DetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Asset asset;
        public DetailsViewModel()
        {
        }
    }
}
