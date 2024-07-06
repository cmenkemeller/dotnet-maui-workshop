namespace MonkeyFinder.ViewModel;

[QueryProperty(nameof(Monkey), "Monkey")]
public partial class MonkeyDetailsViewModel(IMap map) : BaseViewModel
{

    readonly IMap map = map;
    [ObservableProperty]
    Monkey monkey;

    [RelayCommand]
    async Task GetDirections()
    {
        if (Monkey == null)
            return;
        try
        {
            await map.OpenAsync(Monkey.Latitude, Monkey.Longitude,
            new MapLaunchOptions
            {
                Name = Monkey.Name,
                NavigationMode = NavigationMode.None
            });
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
