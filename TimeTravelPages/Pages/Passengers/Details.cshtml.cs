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
    public class DetailsModel : PageModel
    {
        private readonly TimeTravelPages.Data.TimeTravelContext _context;

        public DetailsModel(TimeTravelPages.Data.TimeTravelContext context)
        {
            _context = context;
        }

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
    }
}
