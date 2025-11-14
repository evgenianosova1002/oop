namespace Lab2_Library.Services
{
    public interface IXmlParser
    {
        string Parse(string filePath, string searchValue, string attributeName);
    }
}
