using MobileFront.Services;
using MobileFront.ViewModels;

namespace MobileFront.Views
{
    /// <summary>
    /// The home page that displays a list of assets.
    /// </summary>
    public partial class HomePage : ContentPage
    {
        /// <summary>
        /// Creates a new instance of the HomePage class
        /// </summary>
        /// <param name="assetsServices">Abstraction of services api consumption</param>
        /// <param name="connectivity">The service for checking network connectivit</param>
        public HomePage(IAssetsServices assetsServices, IConnectivity connectivity)
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel(assetsServices, connectivity);
        }

        /// <summary>
        /// Method that is executed when the page is appearing
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is HomePageViewModel viewModel)
            {
                viewModel.GetAssetsCommand.Execute(null);
            }
        }
    }
}
