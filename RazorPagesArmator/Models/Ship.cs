using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesArmator.Models
{
    //klasa reprezentujaca statek,  statek ma nazwe i rpzynaleznosc panstwowa (bandera), mmsi nr statku, jako ze poszczegolne pola mmsi maja znaczenie latwiej jest go przechowywac i wyciagac
    //z niego poszczegolne wartosci z typu string, statek ma swoja dlugosc i szerokosc, typ, statek moze byc w porcie
    public class Ship
    {
        public int Id { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Flag { get; set; }
        [MinLength(9)]
        [MaxLength(9)]
        [Required]
        public string Mmsi { get; set; }

        //nie ma dluzszych statkow niz 400m 
        [Range(1, 500)]
        public int Length { get; set; }
          
        [Range(1, 200)]
        public int Beam { get; set; }
        [Required]
        public string Type { get; set; } = string.Empty;

        public int? PortID { get; set; }//id portu w ktorym jest statek

        public Port? Port { get; set; }
    }
}
