using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimeTravelPages.Data;

namespace TimeTravelPages.Pages.Transporters
{
    public class DetailsModel : PageModel
    {
        private readonly TimeTravelPages.Data.TimeTravelContext _context;

        public DetailsModel(TimeTravelPages.Data.TimeTravelContext context)
        {
            _context = context;
        }

        public Transporter Transporter { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transporter = await _context.Transporters.FirstOrDefaultAsync(m => m.Id == id);

            if (Transporter == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
