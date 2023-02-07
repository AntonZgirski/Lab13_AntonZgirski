using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Xml.Serialization;

namespace _16_ASP.NET_Practice_01_02_2023.Models
{
  public class WorkWithFile
  {    

    public List<Auto> DeserializeList(string path)
    {
      List<Auto> l = new List<Auto>();
      XmlSerializer xml = new XmlSerializer(typeof(List<Auto>));
      using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
      {
        l = (List<Auto>)xml.Deserialize(stream);
      }
      return l;
    }


    public void SerealizeList(List<Auto> l, string path)
    {
      XmlSerializer xml = new XmlSerializer(typeof(List<Auto>));
      using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
      {
        xml.Serialize(stream, l);
      }
    }

    public string GenerateId()
    {
      return Guid.NewGuid().ToString();
    }

  }
}
