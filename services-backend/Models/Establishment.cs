using services_backend.Models;
using System.ComponentModel.DataAnnotations;

public class Establishment
{
    [Key]
    public int IdEstablishment { get; set; }

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
    public string ColorLight { get; set; }
    public string ColorMedium { get; set; }
    public string ColorStrong { get; set; }


    public int State { get; set; }

    
    public ICollection<Client> Clients { get; set; } = new List<Client>();
    public ICollection<Service> Services { get; set; } = new List<Service>();
    public ICollection<TypeService> TypeServices { get; set; } = new List<TypeService>();
}
