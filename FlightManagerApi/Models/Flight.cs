using System.ComponentModel.DataAnnotations;

namespace FlightManagerApi.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public string? Code { get; set; }
        public bool IsAirReady { get; set; }
        public string? Brand { get; set; }
    }
}
