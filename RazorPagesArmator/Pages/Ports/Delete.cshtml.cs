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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesArmator.Data.RazorPagesArmatorContext _context;

        public DeleteModel(RazorPagesArmator.Data.RazorPagesArmatorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Port Port { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Port == null)
            {
                return NotFound();
            }

            var port = await _context.Port.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Port == null)
            {
                return NotFound();
            }
            var port = await _context.Port.FindAsync(id);

            if (port != null)
            {
                Port = port;

                port = _context.Port.OrderBy(e => e.Name).Include(e => e.Ships).First();

                //przed usunieciem portu ustawiam NULL na portach ktore sa w statkach
                foreach (var ship in port.Ships)
                {
                    ship.Port = null;
                }

                _context.Port.Remove(Port);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
