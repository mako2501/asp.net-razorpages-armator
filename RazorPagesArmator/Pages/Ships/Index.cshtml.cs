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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesArmator.Data.RazorPagesArmatorContext _context;

        public IndexModel(RazorPagesArmator.Data.RazorPagesArmatorContext context)
        {
            _context = context;
        }

        public IList<Ship> Ships { get;set; } = default!;

        //szukanie po panstwie
        [BindProperty(SupportsGet = true)]
        public string? SearchNameString { get; set; }

        public SelectList? Flags { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ShipFlag { get; set; }

        public async Task OnGetAsync()
        {
            var ships = from s in _context.Ship
                        select s;

            //wybór statków po banderze
            IQueryable<string> flagQuery = from m in _context.Ship
                                            orderby m.Flag
                                            select m.Flag;

            //wyszukiwanie statków po nazwie
            if (!string.IsNullOrEmpty(SearchNameString))
            {
                ships = ships.Where(s => s.Name.Contains(SearchNameString));
            }

            //i banderze
            if (!string.IsNullOrEmpty(ShipFlag))
            {
                ships = ships.Where(x => x.Flag == ShipFlag);
            }

            //lista dla filtru po banderach statków
            Flags = new SelectList(await flagQuery.Distinct().ToListAsync());

            /*Ships = await _context.Ship //to w tutorialu, ale nie dziala z tym filtrowanie
                .Include(p => p.Port)
                .AsNoTracking()
                .ToListAsync();*/

            Ships = await ships.Include(p => p.Port).OrderBy(s =>s.Name).ToListAsync();


            /* if (_context.Ship != null)
             {
                 Ship = await _context.Ship.ToListAsync();
             }*/
        }
    }
}
