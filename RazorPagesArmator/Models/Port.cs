using System.ComponentModel.DataAnnotations;

namespace RazorPagesArmator.Models
{
    //klasa reprezentujaca port do ktorego wchodzą statki, port ma nazwe i przynaleznosc panstwowa
    public class Port
    {
        public int Id { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Flag { get; set; }

        public ICollection<Ship>? Ships { get; set; }//port moze miec wiele statkow
    }
}
