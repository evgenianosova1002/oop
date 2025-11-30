using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace Lab3
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Book> Books { get; } = new();

        private string _currentFilePath = string.Empty;
        private Book? _selectedBook = null;

        private readonly JsonSerializerOptions _jsonOptions =
            new JsonSerializerOptions
            {
                WriteIndented = true
            };

        public MainPage()
        {
            InitializeComponent();
            SetLibraryUiEnabled(false);
            RefreshBooks();
        }

        private void SetLibraryUiEnabled(bool enabled)
        {
            SaveButton.IsEnabled = enabled;
            AddBookButton.IsEnabled = enabled;
            EditBookButton.IsEnabled = enabled;
            DeleteBookButton.IsEnabled = enabled;
            SearchButton.IsEnabled = enabled;
            ClearSearchButton.IsEnabled = enabled;
        }

        private async void OpenJsonButton_Clicked(object sender, EventArgs e)
        {
            var fileResult = await FilePicker.Default.PickAsync();

            if (fileResult == null)
                return;

            var extension = Path.GetExtension(fileResult.FullPath).ToLowerInvariant();
            if (extension != ".json")
            {
                await DisplayAlert("Wrong file",
                    "This file is not JSON. Please choose a .json library file.",
                    "OK");
                return;
            }

            _currentFilePath = fileResult.FullPath;

            try
            {
                string jsonText = await File.ReadAllTextAsync(_currentFilePath);
                var libraryData = JsonSerializer.Deserialize<LibraryData>(jsonText, _jsonOptions);

                Books.Clear();

                if (libraryData?.Books != null)
                {
                    foreach (var book in libraryData.Books)
                        Books.Add(book);
                }

                _selectedBook = null;
                RefreshBooks();
                SetLibraryUiEnabled(true);

                await DisplayAlert("Library opened",
                    "Books have been loaded from the JSON file.",
                    "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error",
                    $"Could not read the library file:\n{ex.Message}",
                    "OK");
            }
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentFilePath))
            {
                await DisplayAlert("No file",
                    "Please open a library JSON file first.",
                    "OK");
                return;
            }

            try
            {
                var libraryData = new LibraryData
                {
                    Books = Books.ToList()
                };

                string jsonText = JsonSerializer.Serialize(libraryData, _jsonOptions);
                await File.WriteAllTextAsync(_currentFilePath, jsonText);

                await DisplayAlert("Saved",
                    "All changes have been saved to the JSON file.",
                    "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error",
                    $"Could not save the library file:\n{ex.Message}",
                    "OK");
            }
        }

        private async void AddBookButton_Clicked(object sender, EventArgs e)
        {
            var newBook = new Book();
            var formPage = new BookFormPage(newBook, isNewBook: true);

            formPage.Disappearing += (s, args) =>
            {
                if (formPage.IsSaved)
                {
                    Books.Add(newBook);
                    RefreshBooks();
                }
            };

            await Navigation.PushModalAsync(formPage);
        }

        private async void EditBookButton_Clicked(object sender, EventArgs e)
        {
            if (_selectedBook == null)
            {
                await DisplayAlert("No book selected",
                    "First click on a book in the list.",
                    "OK");
                return;
            }

            var formPage = new BookFormPage(_selectedBook, isNewBook: false);

            formPage.Disappearing += (s, args) =>
            {
                if (formPage.IsSaved)
                {
                    RefreshBooks();
                }
            };

            await Navigation.PushModalAsync(formPage);
        }

        private async void DeleteBookButton_Clicked(object sender, EventArgs e)
        {
            if (_selectedBook == null)
            {
                await DisplayAlert("No book selected",
                    "First click on a book in the list.",
                    "OK");
                return;
            }

            bool confirm = await DisplayAlert(
                "Delete book",
                $"Delete \"{_selectedBook.Title}\" from the library?",
                "Yes",
                "No");

            if (confirm)
            {
                Books.Remove(_selectedBook);
                _selectedBook = null;
                RefreshBooks();
            }
        }

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            string titlePart = TitleFilterEntry.Text?.Trim() ?? string.Empty;
            string authorPart = AuthorFilterEntry.Text?.Trim() ?? string.Empty;
            int yearFrom = 0;

            if (!string.IsNullOrWhiteSpace(YearFromEntry.Text))
                int.TryParse(YearFromEntry.Text, out yearFrom);

            var filtered =
                Books.Where(book =>
                        (string.IsNullOrEmpty(titlePart) ||
                         book.Title.Contains(titlePart, StringComparison.OrdinalIgnoreCase)) &&
                        (string.IsNullOrEmpty(authorPart) ||
                         book.Author.Contains(authorPart, StringComparison.OrdinalIgnoreCase)) &&
                        (yearFrom == 0 || book.Year >= yearFrom))
                    .ToList();

            RefreshBooks(filtered);
        }

        private void ClearSearchButton_Clicked(object sender, EventArgs e)
        {
            TitleFilterEntry.Text = string.Empty;
            AuthorFilterEntry.Text = string.Empty;
            YearFromEntry.Text = string.Empty;

            RefreshBooks();
        }

        private void RefreshBooks(IEnumerable<Book>? list = null)
        {
            var source = list?.ToList() ?? Books.ToList();

            BooksPanel.Children.Clear();

            int index = 1;
            foreach (var book in source)
            {
                var frame = new Frame
                {
                    Padding = 10,
                    Margin = new Thickness(0, 5),
                    BackgroundColor = (book == _selectedBook)
                        ? Color.FromArgb("#5b3fd0")
                        : Color.FromRgb(30, 30, 30),
                    CornerRadius = 10
                };

                var label = new Label
                {
                    Text =
                        $"[{index}] {(book == _selectedBook ? "▶ " : "")}\n" +
                        $"Title: {book.Title}\n" +
                        $"Author: {book.Author}\n" +
                        $"Year: {book.Year}\n" +
                        $"Genre: {book.Genre}\n" +
                        $"Available: {book.IsAvailable}\n",
                    FontSize = 16,
                    TextColor = Colors.White
                };

                var tap = new TapGestureRecognizer();
                tap.Tapped += (s, e) =>
                {
                    _selectedBook = book;
                    RefreshBooks(source);
                };

                frame.GestureRecognizers.Add(tap);
                frame.Content = label;

                BooksPanel.Children.Add(frame);
                index++;
            }
        }

        private async void AboutButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AboutPage());
        }
    }
}
