using System.ComponentModel.DataAnnotations;

namespace MVCtest.Models
{
    public class BTC
    {
        [Key]
        public int Transection {get; set;}

        [Required]
        public double USD { get; set; }
        
        public double BTCUSD { get; set; }

        public double Total { get; set; }
    }
}
