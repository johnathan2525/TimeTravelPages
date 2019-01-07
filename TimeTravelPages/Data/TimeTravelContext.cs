using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TimeTravelPages.Data
{
    public class TimeTravelContext : DbContext
    {
        public TimeTravelContext (DbContextOptions<TimeTravelContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Transporter> Transporters { get; set; }
    }
}
