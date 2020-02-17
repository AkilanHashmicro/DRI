using System;
using System.Collections.Generic;

namespace SalesApp.models
{
    public class CalenderModel
    {
        public int WorkOrderId { get; set; }
        public string WorkOrderName { get; set; }
        public string VehicleNames { get; set; }
        public string BookingOrderName { get; set; }
        public String Attendees { get; set; }
        public DateTime Starting_at { get; set; }
        public DateTime Ending_at { get; set; }
        public string Duration { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string TypesOfService { get; set; }

        public CalenderModel(int workOrderId, string workOrderName, List<string> serialNumbers, string subject, List<string> attendees, DateTime startingAt, DateTime endingAt, string duration, string location, string state, List<string> typesOfService)
        {
            WorkOrderId = workOrderId;
            WorkOrderName = workOrderName;
            VehicleNames = String.Join(",", serialNumbers);
            BookingOrderName = subject;
            Attendees = string.Join(", ", attendees);
            Starting_at = startingAt;
            Ending_at = endingAt;
            Duration = duration;
            Location = location;
            State = state;
            TypesOfService = string.Join(", ", typesOfService);
        }
    }
}
