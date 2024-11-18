namespace services_backend.DTOs
{
    public class TypeServiceDto
    {
        public string Name { get; set; }
        public int Active { get; set; }
        public int State { get; set; }

        public string Description { get; set; }
        public string Photo { get; set; }
        public string PolicyCancelation { get; set; }

        public int EstablishmentId { get; set; }
    }
}