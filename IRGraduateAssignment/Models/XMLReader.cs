using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using static IRGraduateAssignment.Models.XMLReader;

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

            var callDetails =
               from cd in doc.Root.Elements("Call")
               select new
               {
                   AnswerState = (string)cd.Element("AnswerState"),
                   CallType = (string)cd.Element("CallType"),
                   CallbackNum = (string)cd.Element("CallbackNumber"),
                   DeviceType = (string)cd.Element("DeviceType"),
                   Direction = (string)cd.Element("Direction"),
                   DisplayName = (string)cd.Element("DisplayName"),
                   Duration = (string)cd.Element("Duration")
               };

            var networkDetails =
                from nw in doc.Root.Descendants("Network")
                select new
                {
                    Address = (string)nw.Element("CDP").Element("Address"),
                    DeviceID = (string)nw.Element("CDP").Element("DeviceId"),
                    Platform = (string)nw.Element("CDP").Element("Platform"),
                    MACAddress = (string)nw.Element("Ethernet").Element("MacAddress"),
                    IPv4Address = (string)nw.Element("IPv4").Element("Address"),
                    IPv6Address = (string)nw.Element("IPv6").Element("Address") 
                };
            //TODO finish capabilities method, not getting correct child node elements currently
            //var capabilities =
            //    from cp in doc.Root.DescendantsAndSelf("Capabilities")
            //    select new
            //    {
            //        Mode = (string)cp.Element("FECC").Element("Mode"),
            //        Hold = (string)cp.Element("Hold"),
            //        Presentation = (string)cp.Element("Presentation"),
            //        SourceName = (string)cp.Element("FECC").Element("Source")
            //    };

            List < SystemUnit > list = new List<SystemUnit>();

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

            foreach (var cd in callDetails)
            {
                SystemUnit call = new SystemUnit
                {
                    AnswerState = cd.AnswerState,
                    CallType = cd.CallType,
                    CallbackNum = cd.CallbackNum,
                    DeviceType = cd.DeviceType,
                    Direction = cd.Direction,
                    DisplayName = cd.DisplayName,
                    Duration = cd.Duration
                };
                list.Add(call);
            }

            //foreach (var cp in capabilities)
            //{
            //    SystemUnit cap = new SystemUnit
            //    {
            //        Mode = cp.Mode,
            //        Hold = cp.Hold,
            //        Presentation = cp.Presentation,
            //        SourceName = cp.SourceName
            //    };
            //    list.Add(cap);
            //}

            foreach (var nw in networkDetails)
            {
                SystemUnit network = new SystemUnit
                {
                    Address = nw.Address,
                    DeviceID = nw.DeviceID,
                    Platform = nw.Platform,
                    MACAddress = nw.MACAddress,
                    IPv4Address = nw.IPv4Address,
                    IPv6Address = nw.IPv6Address == "" ? "No Value" : nw.IPv6Address
                };
                list.Add(network);
            }

            return list;

        }

        public class SystemUnit
        {
            // properties for the system unit
            public string ProductID { get; set; }
            public string ProductPlatform { get; set; }
            public string ProductType { get; set; }
            public string SoftwareDetails { get; set; }
            public string DiagnosticInformation { get; set; }
            public string State { get; set; }
            //properties for the call
            public string AnswerState { get; set; }
            public string CallType { get; set; }
            public string CallbackNum { get; set; }
            public string DeviceType { get; set; }
            public string Direction { get; set; }
            public string DisplayName { get; set; }
            public string Duration { get; set; }
            //properties for the capabilities
            public string Mode { get; set; }
            public string Hold { get; set; }
            public string Presentation { get; set; }
            public string SourceName { get; set; }
            // properties for network info
            public string Address { get; set; }
            public string DeviceID { get; set; }
            public string Platform { get; set; }
            public string MACAddress { get; set; }
            public string IPv4Address { get; set; }
            public string IPv6Address { get; set; }
            //properties for system time
            public DateTime Time { get; set; }
        }
    }
}