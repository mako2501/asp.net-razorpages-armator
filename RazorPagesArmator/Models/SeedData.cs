using Microsoft.EntityFrameworkCore;
using RazorPagesArmator.Data;

namespace RazorPagesArmator.Models
{
    //klasa inicjujaca dane poczatkowe w bazie jesli ich nie ma 
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesArmatorContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesArmatorContext>>()))
            {
                if (context == null || context.Ship == null)
                {
                    throw new ArgumentNullException("Null RazorPagesArmatorContext");
                }

                // jesli baza jest pusta
                /*if (context.Ship.Any() && context.Port.Any())
                {
                    return;

                }*/
                if (!context.Port.Any())
                {
                    context.Port.AddRange(

                        new Port
                        {
                            Name = "Gdynia",
                            Flag = "Poland"
                        },
                        new Port
                        {
                            Name = "Karlshamn",
                            Flag = "Sweden"
                        });
                }

                if (!context.Ship.Any())
                {
                    context.Ship.AddRange(
                    new Ship
                    {
                        Name = "Stena Ebba",
                        Flag = "Denmark",
                        Mmsi = "219031310",
                        Length = 240,
                        Beam = 28,
                        Type = "Cargo Ship"
                    },

                    new Ship
                    {
                        Name = "Sopterix",
                        Flag = "Portugal",
                        Mmsi = "314646000",
                        Length = 108,
                        Beam = 18,
                        Type = "Cargo Ship"
                    },
                    new Ship
                    {
                        Name = "Cape Hellas",
                        Flag = "Cyprus",
                        Mmsi = "210308000",
                        Length = 186,
                        Beam = 35,
                        Type = "Container Ship"
                    },
                    new Ship
                    {
                        Name = "Seastrength",
                        Flag = "Malta",
                        Mmsi = "256503000",
                        Length = 229,
                        Beam = 32,
                        Type = "Tanker"
                    },
                    new Ship
                    {
                        Name = "Amaranth",
                        Flag = "Cyprus",
                        Mmsi = "209507000",
                        Length = 109,
                        Beam = 16,
                        Type = "Tanker"
                    },
                    new Ship
                    {
                        Name = "Eco Dominator",
                        Flag = "Marshall Islands",
                        Mmsi = "538006873",
                        Length = 117,
                        Beam = 18,
                        Type = "LPG Tanker"
                    }
                   
                );
                }

                //gdy nie ma nic, test relacji i statki w porcie
                if (!context.Ship.Any() && !context.Port.Any()) {                    

                    var ship1 = new Ship
                    {
                        Name = "MG Earth",
                        Flag = "Marshall Islands",
                        Mmsi = "538006373",
                        Length = 250,
                        Beam = 28,
                        Type = "LPG Tanker"
                    };
                    
                    context.AddRange(ship1);
                  

                    var port1 = new Port
                    {
                        Name = "Gdańsk",
                        Flag = "Polska",
                        Ships = new List<Ship> { ship1 }
                    };                 
                    context.AddRange(port1);
                 
                }
                context.SaveChanges();
            }
        }
    }
}
