namespace Project5.Models
{
    public class Product
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Country { get; set; }
        public string? PackageDate { get; set; }
        public string? Description { get; set; }
    }

    public class FoodProduct : Product
    {
        public string? ExpirationDate { get; set; }
        public double Quantity { get; set; }
        public string? Unit { get; set; }
    }

    public class Book : Product
    {
        public int Pages { get; set; }
        public string? Publisher { get; set; }
        public string? Authors { get; set; }
    }
}
