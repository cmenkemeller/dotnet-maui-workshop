using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    public ObservableCollection<Monkey> Monkeys { get; } = [];
    MonkeyService monkeyService;
    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkeys of the World";
        this.monkeyService = monkeyService;
    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsLoading)
        {
            return;
        }
        try
        {
            IsLoading = true;
            var monkeys = await monkeyService.GetMonkeys();
            Monkeys.Clear();
            foreach (var monkey in monkeys)
            {
                Monkeys.Add(monkey);
            }
        }
        catch (Exception ex)
        {
            /* display alert */
            await Shell.Current.DisplayAlert("Something went bananas", ex.Message, "OK");
        }
        finally
        {
            IsLoading = false;
        }
    }
}
