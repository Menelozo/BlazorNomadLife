using System.ComponentModel;

namespace NomadLife.Mobile;

public class AppState : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public string _loaderMessage = "Processing";
    public string LoaderMessage
    {
        get => _loaderMessage;
        set
        {
            _loaderMessage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoaderMessage)));
        }
    }

    public bool _isLoaderVisable;
    public bool IsLoaderVisable
    {
        get => _isLoaderVisable;
        set
        {
            if(_isLoaderVisable!=value)
            {
                _isLoaderVisable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLoaderVisable)));
            }
        }
    }

    public void ShowLoader(string? loaderMessage = "Processing...")
    {
        if(string.IsNullOrWhiteSpace(loaderMessage))
        {
            loaderMessage = "Processing...";
        }
        LoaderMessage = loaderMessage;
        IsLoaderVisable = true;
    }

    public void HideLoader()
    {
        LoaderMessage = "Processing...";
        IsLoaderVisable = false;
    }
}
