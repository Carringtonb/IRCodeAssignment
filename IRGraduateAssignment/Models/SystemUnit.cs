using System;
namespace IRGraduateAssignment.Models
{
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
