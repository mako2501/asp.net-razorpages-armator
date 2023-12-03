using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesArmator.Data;
using RazorPagesArmator.Models;

namespace RazorPagesArmator.Pages.Ports
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesArmator.Data.RazorPagesArmatorContext _context;

        public CreateModel(RazorPagesArmator.Data.RazorPagesArmatorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Port Port { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || _context.Port == null || Port == null)
            {
                return Page();
            }

            _context.Port.Add(Port);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
    }
