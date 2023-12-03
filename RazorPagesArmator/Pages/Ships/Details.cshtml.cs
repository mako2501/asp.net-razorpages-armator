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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesArmator.Data.RazorPagesArmatorContext _context;

        public DetailsModel(RazorPagesArmator.Data.RazorPagesArmatorContext context)
        {
            _context = context;
        }

      public Ship Ship { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ship == null)
            {
                return NotFound();
            }

            //var ship = await _context.Ship.FirstOrDefaultAsync(m => m.Id == id);

            var ship = await _context.Ship
                .Include(s => s.Port)
                .FirstOrDefaultAsync(m => m.Id == id);


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
    }
}
