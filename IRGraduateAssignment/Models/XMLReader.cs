using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace IRGraduateAssignment.Models
{
    public class XMLReader
    {
        public static void ReadFile()
        {
            var path = Environment.CurrentDirectory;
            var newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot/status.xml"));
            var doc = XDocument.Load(newPath);

            // currently this variable is returning a null reference
            //TODO fix this method and figure out why the individual element nodes are not being returned correctly
            var capabilities =
                from op in doc.Root.Element("Capabilities").Element("Capabilities").Elements("FECC")
                let Status = op.Element("Status")
                let Options = op.Element("Options")
                let Name = op.Element("Name")
                let SourceId = op.Element("SourceId")
                let Mode = op.Element("Mode")
                select new Capabilities()
                {
                    Options = (string)op.Element("Options"),
                    Name = (string)op.Element("Name"),
                    SourceID = (string)op.Element("SourceId"),
                    Mode = (string)op.Element("Mode"),
                    Status = (string)op.Element("Status")
                };

            string[] resultsCapabilities = new string[5];
            foreach (var op in capabilities)
            {
                Console.WriteLine(op);
                //op.Add(resultsCapabilities);
            };

            //XmlTextReader reader = new XmlTextReader("status.xml");
            //while (reader.Read())
            //{
            //    switch (reader.NodeType)
            //    {
            //        case XmlNodeType.Element: // The node is an element.
            //            Console.Write("<" + reader.Name);
            //            Console.WriteLine(">");
            //            break;
            //        case XmlNodeType.Text: //Display the text in each element.
            //            Console.WriteLine(reader.Value);
            //            break;
            //        case XmlNodeType.EndElement: //Display the end of the element.
            //            Console.Write("</" + reader.Name);
            //            Console.WriteLine(">");
            //            break;
            //    }
            //}
            //Console.ReadLine();
        }
        public class Capabilities
        {
            public string Options { get; set; }
            public string Name { get; set; }
            public string SourceID { get; set; }
            public string Mode { get; set; }
            public string Status { get; set; }

        }
    }
}