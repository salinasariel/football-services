using System.ComponentModel.DataAnnotations;

namespace services_backend.Models
{
    public class TypeService
    {
        [Key]
        public int IdTypeServices { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }
        public int State { get; set; }

        public int EstablishmentId { get; set; }
        public Establishment Establishment { get; set; }

        public ICollection<Service> Services { get; set; }
    }

}
