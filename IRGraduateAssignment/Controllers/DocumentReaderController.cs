using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using IRGraduateAssignment.Models;

namespace IRGraduateAssignment.Controllers
{
    public class DocumentReaderController
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



        public static List<Call> ReadCalls()
        {

            var path = Environment.CurrentDirectory;
            var newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot/status.xml"));
            var doc = XDocument.Load(newPath);

            List<Call> CallList = new List<Call>();


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


            foreach (var cd in callDetails)
            {
                Call call = new Call
                {
                    AnswerState = cd.AnswerState,
                    CallType = cd.CallType,
                    CallbackNum = cd.CallbackNum,
                    DeviceType = cd.DeviceType,
                    Direction = cd.Direction,
                    DisplayName = cd.DisplayName,
                    Duration = cd.Duration
                };

                CallList.Add(call);
            }
            return CallList;
        }
    }
}
