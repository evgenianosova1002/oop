using System.Text;
using System.Xml;

namespace Lab2_Library.Services
{
    public class SaxParser : IXmlParser
    {
        public string Parse(string filePath, string searchValue, string attributeName)
        {
            StringBuilder result = new();
            int count = 0;

            using var reader = XmlReader.Create(filePath);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "book")
                {
                    string? attrValue = reader.GetAttribute(attributeName);
                    if (attrValue != null &&
                        attrValue.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                    {
                        count++;

                        string author = "", title = "";
                        string faculty = reader.GetAttribute("faculty") ?? "";
                        string department = reader.GetAttribute("department") ?? "";
                        string qualification = reader.GetAttribute("qualification") ?? "";
                        string forReaders = reader.GetAttribute("forReaders") ?? "";
                        string position = reader.GetAttribute("position") ?? "";

                        using var innerReader = reader.ReadSubtree();
                        while (innerReader.Read())
                        {
                            if (innerReader.NodeType == XmlNodeType.Element)
                            {
                                switch (innerReader.Name)
                                {
                                    case "author":
                                        author = innerReader.ReadElementContentAsString();
                                        break;
                                    case "title":
                                        title = innerReader.ReadElementContentAsString();
                                        break;
                                }
                            }
                        }

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
            }

            return count > 0
                ? $"{result}Total matches found: {count}"
                : "No matches found.";
        }
    }
}
