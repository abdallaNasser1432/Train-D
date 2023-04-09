using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Train_D.Models
{
    public class ClassTrip
    {
        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public string ClassName { get; set; }
        public int TrainId { get; set; }
        public Class Class { get; set; }


        public decimal ClassPrice { get; set; }
    }
}
