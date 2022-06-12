using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace FlyMe;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCompatibility()
			.ConfigureMauiHandlers(handlers =>
			{
				// Register ALL handlers in the Xamarin Community Toolkit assembly
				// handlers.AddCompatibilityRenderers(typeof(Xamarin.CommunityToolkit.UI.Views.Expander).Assembly);

				// Register just one handler for the control you need
				// handlers.AddCompatibilityRenderer(typeof(Xamarin.CommunityToolkit.UI.Views.Expander), typeof(Xamarin.CommunityToolkit.UI.Views.Expander));
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("fa-solid-900.ttf", "FontAwesome");
			});

		return builder.Build();
	}
}
