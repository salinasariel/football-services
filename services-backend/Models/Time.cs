using System.ComponentModel.DataAnnotations;

namespace services_backend.Models
{
    public class Time
    {
        [Key]
        public int IdTimes { get; set; }
        public string Day { get; set; }
        public TimeSpan InitTime { get; set; }
        public TimeSpan FinishTime { get; set; }

        // Foreign key
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }

}
