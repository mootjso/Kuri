namespace Kuri;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        UpdateGreeting();
    }

    // Prive method om te kijken welke tijdslot het is van de dag / nacht.
    private void UpdateGreeting()
    {
        var currentHour = DateTime.Now.Hour;
        string timeOfDay;

        if (currentHour >= 5 && currentHour < 12)
        {
            timeOfDay = "morning";
        }
        else if (currentHour >= 12 && currentHour < 18)
        {
            timeOfDay = "afternoon";
        }
        else
        {
            timeOfDay = "evening";
        }

        // Nieuwe variable om de tekst kleuren te maken.
        // Hierbij gebruiken we de bovenste method.
        GreetingLabel.FormattedText = new FormattedString
        {
            Spans =
            {
                new Span { Text = $"Good {timeOfDay} ", TextColor = Color.FromArgb("#9367CA") },
                new Span { Text = "User!", TextColor = Color.FromArgb("#BE89FF") }
            }
        };
    }
}