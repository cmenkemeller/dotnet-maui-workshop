namespace MonkeyFinder.View;

public partial class MainPage : ContentPage
{

	MonkeysViewModel viewModel => BindingContext as MonkeysViewModel;
	public MainPage(MonkeysViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await viewModel.InitializeAsync();
	}
}


