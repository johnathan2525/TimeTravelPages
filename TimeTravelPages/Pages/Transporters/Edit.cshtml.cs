using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeTravelPages.Data;

namespace TimeTravelPages.Pages.Transporters
{
    public class EditModel : PageModel
    {
        private readonly TimeTravelPages.Data.TimeTravelContext _context;

        public EditModel(TimeTravelPages.Data.TimeTravelContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Transporter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransporterExists(Transporter.Id))
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

        private bool TransporterExists(int id)
        {
            return _context.Transporters.Any(e => e.Id == id);
        }
    }
}
