using System.ComponentModel.DataAnnotations;

namespace WagglyDBHosting.Models
{
    public class Walkers
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Experience { get; set; }
        public string Location { get; set; }
        public string Availability { get; set; }
        public string Mobile { get; set; }
    }
}
