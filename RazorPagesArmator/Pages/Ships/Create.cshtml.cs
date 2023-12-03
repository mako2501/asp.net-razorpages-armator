using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using RazorPagesArmator.Data;
using RazorPagesArmator.Models;
using static System.Net.Mime.MediaTypeNames;

namespace RazorPagesArmator.Pages.Ships
{
    public class CreateModel : PortsNamePageModel //z mojej klasy
    {

        private readonly RazorPagesArmator.Data.RazorPagesArmatorContext _context;

       

        public CreateModel(RazorPagesArmator.Data.RazorPagesArmatorContext context)
        {
            _context = context;           

        }

        public IActionResult OnGet()
        {
            PopulatePortsDropDownList(_context);

            //shipTypes = new List<SelectListItem>();
             shipTypes = new ShipTypes();
            // shipTypes.Add(new SelectListItem() { Text = "Northern Cape", Value = "NC" });
            //shipTypes.Add(new SelectListItem() { Text = "Free State", Value = "FS" });
            // shipTypes.Add(new SelectListItem() { Text = "Western Cape", Value = "WC" });

            return Page();
        }

        [BindProperty]
        public Ship Ship { get; set; } = default!;
        
        public ShipTypes shipTypes { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            /*
          if (!ModelState.IsValid || _context.Ship == null || Ship == null)
            {
                return Page();
            }
            */

            var emptyShip = new Ship();

           

            if(await TryUpdateModelAsync<Ship>(
                emptyShip,
                "ship",
                    s => s.Name, s => s.Flag, s => s.Mmsi, s => s.Length, s => s.Beam, s => s.Type, s => s.PortID)){

                //w tutorialu https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/update-related-data?view=aspnetcore-7.0
                //podaje kurs z ID, Id nie moze byc tu przekazywany poniewaz obiekt ma byc dopiero stworzony
                _context.Ship.Add(emptyShip);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            PopulatePortsDropDownList(_context, emptyShip.PortID);
            return Page();

            
        }
    }
}
