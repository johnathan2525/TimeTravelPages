using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimeTravelPages.Data;

namespace TimeTravelPages.Pages.Passengers
{
    public class DeleteModel : PageModel
    {
        private readonly TimeTravelPages.Data.TimeTravelContext _context;

        public DeleteModel(TimeTravelPages.Data.TimeTravelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Passenger Passenger { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Passenger = await _context.Passengers
                .Include(p => p.Transporter).FirstOrDefaultAsync(m => m.Id == id);

            if (Passenger == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Passenger = await _context.Passengers.FindAsync(id);

            if (Passenger != null)
            {
                _context.Passengers.Remove(Passenger);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
