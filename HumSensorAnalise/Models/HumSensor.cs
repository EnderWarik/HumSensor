using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumSensorAnalise.Models
{
    //[Table("HumSensor")]
    public class HumSensor
    {

        [Key]
        public int id { get; set; }
        public double? result { get; set; }
        
        public DateTime? dtAdd { get; set; }

    }
}
