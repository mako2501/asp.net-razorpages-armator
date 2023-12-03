using RazorPagesArmator.Data;
using RazorPagesArmator.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

//klasa bazowa dla tworzenia i edytowania statkow - potrzebuje w obu przypadkach liste z nazwami portow, dane z bazy danych
namespace RazorPagesArmator.Pages.Ships
{
    public class PortsNamePageModel : PageModel
    {
        public SelectList PortNameSL {  get; set; }
        //f tworzy liste zawiarajaca nazwy portow
        public void PopulatePortsDropDownList(RazorPagesArmatorContext _context,
            object selectedPort = null)
        {
            var portsQuery = from p in _context.Port
                             orderby p.Name
                             select p;

            PortNameSL = new SelectList(portsQuery.AsNoTracking(),
                nameof(Port.Id),
                nameof(Port.Name),
                selectedPort);

        }
    }
}
