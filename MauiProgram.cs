using MobileFront.Services;
using MobileFront.ViewModels;
using MobileFront.Views;
using AutoMapper;
using MobileFront.Services.ApiServices;

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

        // AutoMapper
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);

        builder.Services.AddSingleton<IAssetsServices, AssetsServices>();
        builder.Services.AddSingleton<IAssetApiClient, AssetApiClient>();
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddTransient<Details>();
        builder.Services.AddTransient<DetailsViewModel>();


        return builder.Build();
	}
}
