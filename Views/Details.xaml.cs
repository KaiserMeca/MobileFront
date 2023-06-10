using MobileFront.Models;
using MobileFront.ViewModels;

namespace MobileFront.Views
{
    /// <summary>
    /// A details page that displays detailed information for an asset.
    /// </summary>
    public partial class Details : ContentPage
    {
        /// <summary>
        /// Creates a new instance of the Details class
        /// </summary>
        /// <param name="vm">The ViewModel associated with the details page</param>
        public Details(DetailsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
