using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesArmator.Data;
using RazorPagesArmator.Models;

namespace RazorPagesArmator.Pages.Ships
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesArmator.Data.RazorPagesArmatorContext _context;

        public DeleteModel(RazorPagesArmator.Data.RazorPagesArmatorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Ship Ship { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ship == null)
            {
                return NotFound();
            }

            var ship = await _context.Ship.FirstOrDefaultAsync(m => m.Id == id);

            if (ship == null)
            {
                return NotFound();
            }
            else 
            {
                Ship = ship;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ship == null)
            {
                return NotFound();
            }
            var ship = await _context.Ship.FindAsync(id);

            if (ship != null)
            {
                Ship = ship;
                _context.Ship.Remove(Ship);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
