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

        public Train Train { get; set; }
        public virtual Station StationBegain { get; set; }
        public virtual Station StationEnd { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<ClassTrip> ClassTrips { get; set; }


    }
}
