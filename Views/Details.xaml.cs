using MobileFront.Models;
using MobileFront.ViewModels;

namespace MobileFront.Views;

public partial class Details : ContentPage
{
    public Details(DetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
