using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace Lab2_Library.Services
{
    public class LinqParser : IXmlParser
    {
        public string Parse(string filePath, string searchValue, string attributeName)
        {
            StringBuilder result = new();
            var doc = XDocument.Load(filePath);
            int count = 0;

            var books = from b in doc.Descendants("book")
                        let attr = (string?)b.Attribute(attributeName)
                        where attr != null &&
                              attr.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                        select new
                        {
                            Id = (string?)b.Attribute("id"),
                            Faculty = (string?)b.Attribute("faculty"),
                            Department = (string?)b.Attribute("department"),
                            Qualification = (string?)b.Attribute("qualification"),
                            ForReaders = (string?)b.Attribute("forReaders"),
                            Position = (string?)b.Attribute("position"),
                            Author = (string?)b.Element("author"),
                            Title = (string?)b.Element("title"),
                            AttrValue = attr
                        };

            foreach (var b in books)
            {
                count++;
                result.AppendLine($"[{count}] Match: {attributeName} = {b.AttrValue}");
                result.AppendLine($"   Author: {b.Author}");
                result.AppendLine($"   Title: {b.Title}");
                result.AppendLine($"   Autor's faculty: {b.Faculty}");
                result.AppendLine($"   Department: {b.Department}");
                result.AppendLine($"   Qualification: {b.Qualification}");
                result.AppendLine($"   For Readers: {b.ForReaders}");
                result.AppendLine($"   Autor's position: {b.Position}");
                result.AppendLine();
            }

            return count > 0
                ? $"{result}Total matches found: {count}"
                : "No matches found.";
        }
    }
}
