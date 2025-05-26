using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents; // Voeg deze using toe

namespace Kuri;

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
            })
            .ConfigureLifecycleEvents(events =>
            {
#if ANDROID
                events.AddAndroid(android => android
                    .OnCreate((activity, bundle) =>
                    {
                        // Maak de statusbalk transparant
                        activity.Window?.SetStatusBarColor(Android.Graphics.Color.Transparent);
                        // Zorg ervoor dat de content onder de statusbalk loopt (optioneel)
                        activity.Window?.SetFlags(
                            Android.Views.WindowManagerFlags.LayoutNoLimits,
                            Android.Views.WindowManagerFlags.LayoutNoLimits
                        );
                    }));
#endif
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}