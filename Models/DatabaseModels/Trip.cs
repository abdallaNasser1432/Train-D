namespace Train_D.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        public string TripName { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan ArrivalTime { get; set; }

        public string StartStation { get; set; }

        public string EndStaion { get; set; }
        public int TrainId { get; set; }

        // (one to many ) relationship with Trains Table
        public Train Train { get; set; }

        // (one to many ) relationship with Stations Table
        public Station StationBegain { get; set; }

        // (one to many ) relationship with Stations Table
        public Station StationEnd { get; set; }

        // (many to one ) relationship with Tickets Table
        public List<Ticket> Tickets { get; set; }

        // (many to one ) relationship with ClassTrips Table
        public List<ClassTrip> ClassTrips { get; set; }


    }
}
