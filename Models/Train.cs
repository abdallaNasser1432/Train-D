namespace Train_D.Models
{
    public class Train
    {
        public int TrainId { get; set; }

        // (many to one ) relationship with Classes Table
        public virtual List<Class> Classes { get; set; }

        // (many to one ) relationship with Trips Table
        public virtual List<Trip> Trips { get; set; }
    }
}
