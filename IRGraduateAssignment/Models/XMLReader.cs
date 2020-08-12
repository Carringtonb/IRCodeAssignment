using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace IRGraduateAssignment.Models
{
    public class XMLReader
    {
        public static List<SystemUnit> ReadFile()
        {
            var path = Environment.CurrentDirectory;
            var newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot/status.xml"));
            var doc = XDocument.Load(newPath);

            
            var dataLog =
                from op in doc.Root.Elements("SystemUnit")
                select new
                {
                    ProductId = (string)op.Element("ProductId"),
                    ProductPlatform = (string)op.Element("ProductPlatform"),
                    ProductType = (string)op.Element("ProductType"),
                    Software = (string)op.Element("Software"),
                    Diagnostics = (string)op.Element("Diagnostics"),
                    State = (string)op.Element("State")

                };

            List<SystemUnit> list = new List<SystemUnit>();

            foreach (var op in dataLog)
            {
                SystemUnit systemUnit = new SystemUnit
                {
                    DiagnosticInformation = op.Diagnostics,
                    ProductID = op.ProductId,
                    ProductPlatform = op.ProductPlatform,
                    ProductType = op.ProductType,
                    SoftwareDetails = op.Software,
                    State = op.State
                };
                
                list.Add(systemUnit);
            };
            return list;

        }
        public class Capabilities
        {
            public string Options { get; set; }
            public string Name { get; set; }
            public string SourceID { get; set; }
            public string Mode { get; set; }
            public string Status { get; set; }

        }

        public class SystemUnit
        {
            public string ProductID { get; set; }
            public string ProductPlatform { get; set; }
            public string ProductType { get; set; }
            public string SoftwareDetails { get; set; }
            public string DiagnosticInformation { get; set; }
            public string State { get; set; }
        }
    }
}