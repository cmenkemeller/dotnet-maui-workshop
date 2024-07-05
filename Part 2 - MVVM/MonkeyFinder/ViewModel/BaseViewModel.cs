namespace MonkeyFinder.ViewModel;
public partial class BaseViewModel : ObservableObject
{

    public BaseViewModel()
    {
        Title = "Monkey Finder";
    }
    [ObservableProperty]
    bool isLoading;
    [ObservableProperty]
    string title;


}
