using System;
using System.Dynamic;
using System.Xml.Linq;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        GetBooksXml();

        Console.ReadKey();
    }

    static void GetBooksXml()
    {
        XDocument doc = XDocument.Load("https://csharptraining.blob.core.windows.net/files/book.xml");
        foreach(var book in doc.Document.Element("catalog").Elements("book"))
        {
            Console.WriteLine($"Title: {book.Element("title").Value}; Price: {book.Element("price").Value} Euro; Released: {book.Element("publish_date").Value}");
        }

        Console.WriteLine("\nAusgabe aus dem dynamic Objekt:\n");

        string jsonText = JsonConvert.SerializeXNode(doc);
        dynamic dynXml = JsonConvert.DeserializeObject<ExpandoObject>(jsonText);
        foreach(var book in dynXml.catalog.book)
        {
            Console.WriteLine($"Title: {book.title}; Price: {book.price} Euro; Released: {book.publish_date}");
        }
    }
}
