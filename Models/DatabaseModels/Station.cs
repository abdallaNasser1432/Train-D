using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Train_D.Models
{
    public class Station
    {
        [MaxLength(20)]
        public string StationName { get; set; }

        [MaxLength(11), MinLength(11)]
        public string Phone { get; set; }

        public string StationInfo { get; set; }

        public int HoursOpen { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public string Address { get; set; }

        // (many to one) relationship with Trip Table
        [JsonIgnore]
        public virtual List<Trip> TripsStart { get; set; }

        // (many to one) relationship with Trip Table
        [JsonIgnore]
        public virtual List<Trip> TripsEnd { get; set; }
    }
}
