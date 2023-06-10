using CommunityToolkit.Mvvm.ComponentModel;

namespace MobileFront.ViewModels
{
    /// <summary>
    /// Base class for view models that implements property change notification
    /// </summary>
    public partial class BaseViewModel : ObservableObject
    {
        /// <summary>
        /// Indicates if the view model is busy performing some task
        /// </summary>
        [ObservableProperty]
        bool isBusy;

        /// <summary>
        /// The title of the view
        /// </summary>
        [ObservableProperty]
        string title;
    }
}
