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
        /// <summary>
        /// Read and parse all desired information from the selected xml file. Organize data into a DTO to be passed to the front end for rendering
        /// </summary>
        /// <returns>List of all SystemUnit properties retrieved from xml file</returns>
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

            var systemTime =
                from st in doc.Root.Elements("Time")
                select new
                {
                    SystemTime = (string)st.Element("SystemTime")
                };

            var contact =
                from ct in doc.Root.Elements("UserInterface")
                select new
                {
                    Name = (string)ct.Element("ContactInfo").Element("Name"),
                    Number = (string)ct.Element("ContactInfo").Element("ContactMethod").Element("Number")
                };

            var peri =
                from pr in doc.Root.Elements("Peripherals")
                select new
                {
                    PeriHardware = (string)pr.Element("ConnectedDevice").Element("HardwareInfo"),
                    PeriId = (string)pr.Element("ConnectedDevice").Element("ID"),
                    PeriName = (string)pr.Element("ConnectedDevice").Element("Name"),
                    PeriSoftware = (string)pr.Element("ConnectedDevice").Element("SoftwareInfo"),
                    Peristatus = (string)pr.Element("ConnectedDevice").Element("Status"),
                    PeriType = (string)pr.Element("ConnectedDevice").Element("Type")
                };

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

            foreach (var st in systemTime)
            {
                SystemUnit time = new SystemUnit
                {
                    Time = st.SystemTime
                };
                list.Add(time);
            }

            foreach (var ct in contact)
            {
                SystemUnit contactDetails = new SystemUnit
                {
                    Name = ct.Name,
                    Number = ct.Number
                };
                list.Add(contactDetails);
            }

            foreach (var pr in peri)
            {
                SystemUnit peripherals = new SystemUnit
                {
                    PeriHardware = pr.PeriHardware,
                    PeriID = pr.PeriId,
                    PeriName = pr.PeriName,
                    PeriSoftware = pr.PeriSoftware,
                    PeriStatus = pr.Peristatus,
                    PeriType = pr.PeriType
                };
                list.Add(peripherals);
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
            // properties for network info
            public string Address { get; set; }
            public string DeviceID { get; set; }
            public string Platform { get; set; }
            public string MACAddress { get; set; }
            public string IPv4Address { get; set; }
            public string IPv6Address { get; set; }
            //properties for system time
            public string Time { get; set; }
            //properties for contact info
            public string Number { get; set; }
            public string Name { get; set; }
            //properties for peripherals
            public string PeriHardware { get; set; }
            public string PeriID { get; set; }
            public string PeriName { get; set; }
            public string PeriSoftware { get; set; }
            public string PeriStatus { get; set; }
            public string PeriType { get; set; }
        }
    }
}