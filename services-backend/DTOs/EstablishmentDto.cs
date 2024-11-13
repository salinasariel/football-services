// DTO para crear el establecimiento
using System.ComponentModel.DataAnnotations;

namespace services_backend.DTOs
{
    public class EstablishmentDto
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string EstablishmentVarchar { get; set; }

        public string Coordinates { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string CancellationPolicy { get; set; }
        public int State { get; set; }
    }
}
