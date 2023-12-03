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

namespace RazorPagesArmator.Pages.Ports
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesArmator.Data.RazorPagesArmatorContext _context;

        public EditModel(RazorPagesArmator.Data.RazorPagesArmatorContext context)
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

            var port =  await _context.Port.FirstOrDefaultAsync(m => m.Id == id);
            if (port == null)
            {
                return NotFound();
            }
            Port = port;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Port).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortExists(Port.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PortExists(int id)
        {
          return (_context.Port?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
