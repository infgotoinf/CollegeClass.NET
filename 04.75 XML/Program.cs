using System.Xml.Linq;

class Program
{
    static void Main()
    {
        XDocument contactsDoc = new XDocument(
            new XElement("Contents",
                new XElement("Contact",
                    new XElement("Name", "UwUw"),
                    new XElement("Phone", "88005553535")
                ),
                new XElement("Contact",
                    new XElement("Name", "Eue"),
                    new XElement("Phone", "666777228337")
                )
            )
        );
        contactsDoc.Save("C:\\Users\\studentcoll\\Desktop\\UwU\\.NET\\CollegeClass.NET\\contacts.xml");
    }
}
