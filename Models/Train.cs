namespace Train_D.Models
{
    public class Train
    {
        public int TrainId { get; set; }

        public virtual List<Class> Classes { get; set; }
        public virtual List<Trip> Trips { get; set; }
    }
}
