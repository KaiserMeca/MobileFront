using CommunityToolkit.Mvvm.ComponentModel;
using MobileFront.Models.DTOs;

namespace MobileFront.ViewModels
{
    /// <summary>
    /// ViewModel for the detail view that receives the selected asset on the HomePage
    /// </summary>
    [QueryProperty(nameof(Asset), "assetKey")]
    public partial class DetailsViewModel : ObservableObject
    {
        /// <summary>
        /// The AssetDTO that represents the received asset to display in the details view
        /// </summary>
        [ObservableProperty]
        AssetDTO asset;

        public DetailsViewModel()
        {
        }
    }
}
