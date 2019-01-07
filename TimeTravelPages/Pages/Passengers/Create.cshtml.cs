using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimeTravelPages.Data;

namespace TimeTravelPages.Pages.Passengers
{
    public class CreateModel : PageModel
    {
        private readonly TimeTravelPages.Data.TimeTravelContext _context;

        public CreateModel(TimeTravelPages.Data.TimeTravelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TransporterId"] = new SelectList(_context.Transporters, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Passenger Passenger { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Passengers.Add(Passenger);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}