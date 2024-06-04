namespace NomadLife.Mobile;

public partial class App : Application
{
    public App(AppState appState)
    {
        InitializeComponent();

        MainPage = new MainPage(appState);
    }
}
