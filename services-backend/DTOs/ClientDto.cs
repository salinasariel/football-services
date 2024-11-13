using System.ComponentModel.DataAnnotations;

namespace services_backend.DTOs
{
    public class ClientDto
    {
        public int IdClients { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int EstablishmentId { get; set; }
    }
}
