using services_backend.Models;
using System.ComponentModel.DataAnnotations;

public class Client
{
    [Key] // Esta anotación indica que IdClients es la clave primaria
    public int IdClients { get; set; }

    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int State { get; set; }
    public int Ban { get; set; }

    // Foreign key
    public int EstablishmentId { get; set; }
    public Establishment Establishment { get; set; }

    // Navigation properties
    public ICollection<Reservation> Reservations { get; set; }
}
