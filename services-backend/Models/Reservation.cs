using System.ComponentModel.DataAnnotations;

namespace services_backend.Models
{
    public class Reservation
    {
        [Key]
        public int IdReservations { get; set; }
        public DateTime Day { get; set; }
        public TimeSpan InitTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public int Cancel { get; set; }

        // Foreign keys
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int EstablishmentId { get; set; }
        public Establishment Establishment { get; set; }
    }

}
