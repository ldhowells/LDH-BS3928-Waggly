using System.ComponentModel.DataAnnotations;

namespace WagglyDBHosting.Models
{
    public class Pets
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Age { get; set; }
        public string Breed { get; set; }
        public string Owner { get; set; }
        public string Mobile { get; set; }
    }
}
