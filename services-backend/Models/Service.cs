using System.ComponentModel.DataAnnotations;

namespace services_backend.Models
{
    public class Service
    {
        [Key]
        public int IdServices { get; set; }
        public int Amount { get; set; }
        public string Capacity { get; set; }
        public string Name { get; set; }
        public int State { get; set; }

        // Foreign keys
        public int EstablishmentId { get; set; }
        public Establishment Establishment { get; set; }

        public int TypeServiceId { get; set; }
        public TypeService TypeService { get; set; }
        

        // Navigation properties
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Times> Times { get; set; }
    }

}
