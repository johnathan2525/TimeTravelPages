using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeTravelPages.Data;

namespace TimeTravelPages.Pages.Passengers
{
    public class EditModel : PageModel
    {
        private readonly TimeTravelPages.Data.TimeTravelContext _context;

        public EditModel(TimeTravelPages.Data.TimeTravelContext context)
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
           ViewData["TransporterId"] = new SelectList(_context.Transporters, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Passenger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerExists(Passenger.Id))
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

        private bool PassengerExists(int id)
        {
            return _context.Passengers.Any(e => e.Id == id);
        }
    }
}
