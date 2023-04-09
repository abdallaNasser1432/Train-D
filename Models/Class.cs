using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Train_D.Models
{
    public class Class
    {
        [MaxLength(2)]
        public string ClassName { get; set; }

        public int Coaches { get; set; }

        public int NumberOfSeatsCoach { get; set; }

        public int TrainId { get; set; }

        public virtual Train Train { get; set; }
        public List<ClassTrip> ClassTrips { get; set; }

    }

}
