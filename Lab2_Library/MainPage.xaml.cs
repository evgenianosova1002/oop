using Lab2_Library.Services;
using System.Xml;
using System.Xml.Xsl;

namespace Lab2_Library;

public partial class MainPage : ContentPage
{
    private string? xmlPath;
    private string? xslPath;
    private string htmlOutput = Path.Combine(FileSystem.Current.AppDataDirectory, "result.html");

    private IXmlParser? parser;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnSelectXmlClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select XML file",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                { DevicePlatform.WinUI, new[] { ".xml" } },
                { DevicePlatform.Android, new[] { ".xml" } },
                { DevicePlatform.iOS, new[] { ".xml" } },
                { DevicePlatform.MacCatalyst, new[] { ".xml" } }
                })
            });

            if (result != null)
            {
                xmlPath = result.FullPath;
                OutputLabel.Text = $" XML file loaded: {Path.GetFileName(xmlPath)}";

                LoadAttributesFromXml(xmlPath);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void OnSelectXslClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select XSL file",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
{
    { DevicePlatform.WinUI, new[] { ".xsl" } },
    { DevicePlatform.Android, new[] { ".xsl" } },
    { DevicePlatform.iOS, new[] { ".xsl" } },
    { DevicePlatform.MacCatalyst, new[] { ".xsl" } }
})
            });

            if (result != null)
            {
                xslPath = result.FullPath;
                OutputLabel.Text += $"\n XSL file loaded: {Path.GetFileName(xslPath)}";
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private void OnParseClicked(object sender, EventArgs e)
    {
        OutputLabel.Text = "";

        if (xmlPath == null)
        {
            DisplayAlert("Error", "Please select XML file first.", "OK");
            return;
        }

        string selected = ParserPicker.SelectedItem?.ToString() ?? "";
        parser = selected switch
        {
            "SAX" => new SaxParser(),
            "DOM" => new DomParser(),
            "LINQ" => new LinqParser(),
            _ => null
        };

        if (parser == null)
        {
            DisplayAlert("Error", "Please select parser method.", "OK");
            return;
        }

        string attribute = AttributePicker.SelectedItem?.ToString() ?? "";
        string search = SearchEntry.Text ?? "";

        if (string.IsNullOrEmpty(attribute))
        {
            DisplayAlert("Error", "Please choose an attribute for search.", "OK");
            return;
        }

        OutputLabel.Text = parser.Parse(xmlPath, search, attribute);
    }

    private void OnTransformClicked(object sender, EventArgs e)
    {
        try
        {
            if (xmlPath == null || xslPath == null)
            {
                DisplayAlert("Error", "Please select XML and XSL files.", "OK");
                return;
            }

            var xslt = new XslCompiledTransform();
            xslt.Load(xslPath);
            xslt.Transform(xmlPath, htmlOutput);
            DisplayAlert("Success", $"HTML created: {htmlOutput}", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        SearchEntry.Text = "";
        OutputLabel.Text = "";
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Exit", "Do you really want to exit?", "Yes", "No");
        if (confirm)
            System.Diagnostics.Process.GetCurrentProcess().Kill();
    }

    private void LoadAttributesFromXml(string path)
    {
        try
        {
            var doc = new XmlDocument();
            doc.Load(path);
            var firstBook = doc.SelectSingleNode("//book");

            if (firstBook?.Attributes != null)
            {
                AttributePicker.Items.Clear();
                foreach (XmlAttribute attr in firstBook.Attributes)
                {
                    AttributePicker.Items.Add(attr.Name);
                }
            }
        }
        catch
        {
            DisplayAlert("Error", "Failed to read attributes from XML.", "OK");
        }
    }
}
