using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace IRGraduateAssignment.Models
{
    public class Capabilities
    {
        public string Options { get; set; }
        public string Name { get; set; }
        public string SourceID { get; set; }
        public string Mode { get; set; }
        public string Status { get; set; }

        public Capabilities(string options, string name, string sourceID, string mode, string status)
        {
            Options = options;
            Name = name;
            SourceID = sourceID;
            Mode = mode;
            Status = status;
        }

        public static string [] GetCapabilities()
        {

            var path = Environment.CurrentDirectory;
            var newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot/status.xml"));

            var xDoc = XDocument.Load(newPath);//This is your xml path value

            var userVar = xDoc.Descendants("Capabilities")
                              .FirstOrDefault();

            //var options = userVar.Element("Options").Value ?? string.Empty;
            //var connected = userVar.Element("Connected").Value ?? string.Empty;
            //var manufacturer = userVar.Element("Manufacturer").Value ?? string.Empty;
            //var model = userVar.Element("Model").Value ?? string.Empty;
            //var serialNumber = userVar.Element("SerialNumber").Value ?? string.Empty;

            var values = from m in xDoc.Root.Elements("Status")
                         let d = m.Element("Capabilities")
                         select new
                         {
                             Options = (string)d.Element("Options"),
                             Name = (string)d.Element("Name"),
                             SourceID = (string)d.Element("SourceId"),
                             Mode = (string)d.Element("Mode"),
                             Status = (string)d.Element("Status")
                         };

            string[] results = new string[5];

            XElement root = XElement.Load(newPath);
            IEnumerable<XElement> capabilities =
                from el in root.Elements("Capabilities")
                where (bool)el.Attribute("Mode")
                select el;
            foreach (XElement el in capabilities)
            {
                el.Add(results);
            }
            return results;
        }
   }
}
