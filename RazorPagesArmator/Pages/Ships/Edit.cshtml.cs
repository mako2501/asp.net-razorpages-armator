using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesArmator.Data;
using RazorPagesArmator.Models;

namespace RazorPagesArmator.Pages.Ships
{
    public class EditModel : PortsNamePageModel //z mojej klasy
    {
        private readonly RazorPagesArmator.Data.RazorPagesArmatorContext _context;

        public EditModel(RazorPagesArmator.Data.RazorPagesArmatorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ship Ship { get; set; } = default!;
        public ShipTypes shipTypes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ship == null)
            {
                return NotFound();
            }

            shipTypes = new ShipTypes();

            //takze dane portu po id
            Ship = await _context.Ship
                .Include(s => s.Port).FirstOrDefaultAsync(m => m.Id == id);

            //var ship =  await _context.Ship.Include(s => s.Port).FirstOrDefaultAsync(m => m.Id == id);

            if (Ship == null)
            {
                return NotFound();
            }

            PopulatePortsDropDownList(_context, Ship.PortID); //do uzupelnienia selecta

            //Ship = ship;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipToUpdate = await _context.Ship.FindAsync(id);

            if (shipToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Ship>(
                 shipToUpdate,
                 "ship",
                   s => s.Name, s => s.Flag, s => s.Mmsi, s => s.Length, s => s.Beam, s => s.Type, s => s.PortID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulatePortsDropDownList(_context, shipToUpdate.PortID);
            return Page();
            /*if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipExists(Ship.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            */

        }

        /*private bool ShipExists(int id)
        {
          return (_context.Ship?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
