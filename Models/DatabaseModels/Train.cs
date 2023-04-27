namespace Train_D.Models
{
    public class Train
    {
        public int TrainId { get; set; }

        // (many to one ) relationship with Classes Table
        public List<Class> Classes { get; set; }    

        // (many to one ) relationship with Trips Table
        public List<Trip> Trips { get; set; }
    }
}
