using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeTravelPages.Data;

namespace TimeTravelPages.Pages.Passenger
{
    public class EditModel : PageModel
    {
        private readonly TimeTravelContext _db;

        public EditModel(TimeTravelContext db)
        {
            _db = db;
        }

        [BindProperty] public Data.Passenger Passenger { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Passenger = await _db.Passengers.FindAsync(id);

            if (Passenger == null)
            {
                throw new Exception($"Passenger not found!");
            }

            ViewData["Transporters"] = new SelectList(_db.Transporters, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(Passenger).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Passenger {Passenger.Id} not found!");
            }

            return RedirectToPage("/Index");
        }
    }
}