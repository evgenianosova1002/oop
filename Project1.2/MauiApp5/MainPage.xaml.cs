namespace MauiApp5;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnConfirmClicked(object sender, EventArgs e)
    {
        if (int.TryParse(numberEntry.Text, out int n))
        {
            DisplayAlert("Result", $"You entered number {n}", "OK");
        }
        else
        {
            DisplayAlert("Error", "Please enter a valid integer!", "OK");
        }
    }
}
