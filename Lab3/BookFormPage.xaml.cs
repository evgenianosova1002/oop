using System;
using Microsoft.Maui.Controls;

namespace Lab3;

public partial class BookFormPage : ContentPage
{
    private Book _book;

    public bool IsNewBook { get; }
    public bool IsSaved { get; private set; }

    public BookFormPage()
    {
        InitializeComponent();
    }

    public BookFormPage(Book book, bool isNewBook) : this()
    {
        _book = book;
        IsNewBook = isNewBook;

        TitleEntry.Text = _book.Title;
        AuthorEntry.Text = _book.Author;
        YearEntry.Text = _book.Year == 0 ? string.Empty : _book.Year.ToString();
        GenreEntry.Text = _book.Genre;
        AvailableSwitch.IsToggled = _book.IsAvailable;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TitleEntry.Text))
        {
            await DisplayAlert("Error", "Title is required.", "OK");
            return;
        }

        int year = 0;
        if (!string.IsNullOrWhiteSpace(YearEntry.Text))
            int.TryParse(YearEntry.Text, out year);

        _book.Title = TitleEntry.Text.Trim();
        _book.Author = (AuthorEntry.Text ?? string.Empty).Trim();
        _book.Year = year;
        _book.Genre = (GenreEntry.Text ?? string.Empty).Trim();
        _book.IsAvailable = AvailableSwitch.IsToggled;

        IsSaved = true;

        await Navigation.PopModalAsync();
    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        IsSaved = false;
        await Navigation.PopModalAsync();
    }
}
