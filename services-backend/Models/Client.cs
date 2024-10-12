using services_backend.Models;
using System.ComponentModel.DataAnnotations;

public class Client
{
    [Key] 
    public int IdClients { get; set; }

    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int State { get; set; }
    public int Ban { get; set; }

    
    public int EstablishmentId { get; set; }
    public Establishment Establishment { get; set; }

    
    public ICollection<Reservation> Reservations { get; set; }
}
