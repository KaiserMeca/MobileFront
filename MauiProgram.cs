using MobileFront.Services;
using MobileFront.ViewModels;
using MobileFront.Views;

namespace MobileFront;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddSingleton<IAssetsServices, AssetsServices>();
        builder.Services.AddSingleton<AssetsListViewModel>();
		builder.Services.AddTransient<HomePage>();


        return builder.Build();
	}
}
