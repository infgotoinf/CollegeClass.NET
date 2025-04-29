using System.Xml.Linq;

class Program
{
    static void Main()
    {
        XDocument document = XDocument.Load("C:\\Users\\studentcoll\\Desktop\\UwU\\.NET\\CollegeClass.NET\\xml.xml");
        var doc = document.Descendants("Products").Descendants("Product");

        var electronics = doc.Where(c => c.Element("Category").Value == "Electronics");
        foreach ( var item in electronics)
        {
            Console.WriteLine(item.Element("Name").Value);
        }
        Console.WriteLine();

        var avalible = doc.Where(c => c.Element("Avalible").Value == "true");
        foreach (var item in avalible)
        {
            Console.WriteLine(item.Element("Name").Value);
        }
        Console.WriteLine();
    }
}