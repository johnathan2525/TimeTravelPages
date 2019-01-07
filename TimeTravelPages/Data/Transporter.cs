
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTravelPages.Data
{
    public class Transporter
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Passenger> Passengers { get; set; }

    }
}
