using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesArmator.Data;
using RazorPagesArmator.Models;

namespace RazorPagesArmator.Pages.Ports
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesArmator.Data.RazorPagesArmatorContext _context;

        public DetailsModel(RazorPagesArmator.Data.RazorPagesArmatorContext context)
        {
            _context = context;
        }

      public Port Port { get; set; } = default!;

        //public int ShipID { get; set; } //statki w porcie

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Port == null)
            {
                return NotFound();
            }


            //var port = await _context.Port.FirstOrDefaultAsync(m => m.Id == id);
            // .Include(s => s.Ships)
            // .AsNoTracking()
            // .ToListAsync();
            
            var port = await _context.Port
                .Include(s => s.Ships)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (port == null)
            {
                return NotFound();
            }
            else 
            {
                Port = port;
            }
            return Page();
        }
    }
}
