using System.ComponentModel.DataAnnotations;

namespace services_backend.Models
{
    public class Reservation
    {
        [Key]
        public int IdReservations { get; set; }
        public DateTime Day { get; set; }
        public DateTime InitTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int Cancel { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int EstablishmentId { get; set; }
        public Establishment Establishment { get; set; }
    }

}
