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
    public class IndexModel : PageModel
    {
        private readonly TimeTravelPages.Data.TimeTravelContext _context;

        public IndexModel(TimeTravelPages.Data.TimeTravelContext context)
        {
            _context = context;
        }

        public IList<Passenger> Passenger { get;set; }

        public async Task OnGetAsync()
        {
            Passenger = await _context.Passengers
                .Include(p => p.Transporter).ToListAsync();
        }
    }
}
