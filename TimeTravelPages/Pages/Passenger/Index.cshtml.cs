using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimeTravelPages.Data;

namespace TimeTravelPages.Pages.Passenger
{
    public class IndexModel : PageModel
    {

        private readonly TimeTravelContext _db;

        [BindProperty]
        public IList<TimeTravelPages.Data.Passenger> Passengers { get; set; }

        public IndexModel(TimeTravelContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Passengers = await _db.Passengers.Include("Transporter").AsNoTracking().ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var contact = await _db.Passengers.FindAsync(id);

            if (contact != null)
            {
                _db.Passengers.Remove(contact);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }

    }
}
