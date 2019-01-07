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
    public class DeleteModel : PageModel
    {
        private readonly TimeTravelPages.Data.TimeTravelContext _context;

        public DeleteModel(TimeTravelPages.Data.TimeTravelContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transporter = await _context.Transporters.FindAsync(id);

            if (Transporter != null)
            {
                _context.Transporters.Remove(Transporter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
