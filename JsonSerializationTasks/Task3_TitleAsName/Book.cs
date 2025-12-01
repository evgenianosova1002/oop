using System.Text.Json.Serialization;

public class BookInput
{
    public int PublishingHouseId { get; set; }
    public string Title { get; set; } = string.Empty;
    public PublishingHouse PublishingHouse { get; set; } = new PublishingHouse();
}

public class Book
{
    public int PublishingHouseId { get; set; }

    [JsonPropertyName("Name")]
    public string Title { get; set; } = string.Empty;

    public PublishingHouse PublishingHouse { get; set; } = new PublishingHouse();
}

public class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Adress { get; set; } = string.Empty;
}
