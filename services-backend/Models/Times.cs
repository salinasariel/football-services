using System.ComponentModel.DataAnnotations;

namespace services_backend.Models
{
    public class Times
    {
        [Key]
        public int IdTimes { get; set; }
        public int Day { get; set; }
        /*
        Lunes        - 1
        Martes       - 2
        Miercoles    - 3
        Jueves       - 4
        Viernes      - 5
        Sabado       - 6
        Domingo      - 7
        */
        public DateTime InitTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int State { get; set; }

        
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }

}
