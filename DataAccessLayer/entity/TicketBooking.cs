using System;

namespace DataAccessLayer.entity
{
    public class TicketBooking
    {
        public long TicketID { get; set; }
        public string Busname { get; set; }
        public string Startingpoint { get; set; }
        public string Droppingpoint { get; set; }
        public long Amount { get; set; }
        public long NoOfpeople { get; set; }
        public DateTime JourneyDate { get; set; }
        public long ContactNo { get; set; }
    }
}
