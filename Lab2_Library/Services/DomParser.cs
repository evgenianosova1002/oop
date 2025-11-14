using System.Text;
using System.Xml;

namespace Lab2_Library.Services
{
    public class DomParser : IXmlParser
    {
        public string Parse(string filePath, string searchValue, string attributeName)
        {
            StringBuilder result = new();
            XmlDocument doc = new();
            doc.Load(filePath);

            int count = 0;

            foreach (XmlNode book in doc.GetElementsByTagName("book"))
            {
                string attrValue = book.Attributes?[attributeName]?.Value ?? "";

                if (!string.IsNullOrEmpty(attrValue) &&
                    attrValue.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                {
                    count++;

                    string author = book["author"]?.InnerText ?? "";
                    string title = book["title"]?.InnerText ?? "";
                    string faculty = book.Attributes?["faculty"]?.Value ?? "";
                    string department = book.Attributes?["department"]?.Value ?? "";
                    string qualification = book.Attributes?["qualification"]?.Value ?? "";
                    string forReaders = book.Attributes?["forReaders"]?.Value ?? "";
                    string position = book.Attributes?["position"]?.Value ?? "";

                    result.AppendLine($"[{count}] Match: {attributeName} = {attrValue}");
                    result.AppendLine($"   Author: {author}");
                    result.AppendLine($"   Title: {title}");
                    result.AppendLine($"   Autor's faculty: {faculty}");
                    result.AppendLine($"   Department: {department}");
                    result.AppendLine($"   Qualification: {qualification}");
                    result.AppendLine($"   For Readers: {forReaders}");
                    result.AppendLine($"   Autor's position: {position}");
                    result.AppendLine();
                }
            }

            return count > 0
                ? $"{result}Total matches found: {count}"
                : "No matches found.";
        }
    }
}
