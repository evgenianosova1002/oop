using Project5.Models;

namespace Project5;

public partial class MainPage : ContentPage
{
    private List<Product> products = new();

    public MainPage()
    {
        InitializeComponent();
        LoadInitialData();
        DisplayProducts();
    }

    private void LoadInitialData()
    {
        products.Add(new FoodProduct { Name = "Bread", Price = 25, Country = "Ukraine", Description = "Fresh rye bread" });
        products.Add(new Book { Name = "C# Basics", Price = 300, Country = "Poland", Description = "Programming guide", Authors = "Є. Носова" });
    }

    private void DisplayProducts()
    {
        ProductsGrid.Children.Clear();
        int row = 0;

        foreach (var p in products)
        {
            ProductsGrid.Add(new Label
            {
                Text = $"{p.Name} - {p.Price}₴ ({p.Country})",
                FontSize = 16
            }, 0, row);
            row++;
        }
    }

    private void OnAddProduct(object sender, EventArgs e)
    {
        products.Add(new Product
        {
            Name = "New Item",
            Price = 100,
            Country = "USA",
            Description = "Example"
        });
        DisplayProducts();
    }

    private void OnRemoveProduct(object sender, EventArgs e)
    {
        if (products.Count > 0)
        {
            products.RemoveAt(products.Count - 1);
            DisplayProducts();
        }
    }
}
