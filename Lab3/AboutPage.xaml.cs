using Microsoft.Maui.Controls;

namespace Lab3;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    private async void CloseButton_Clicked(object sender, System.EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
