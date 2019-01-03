using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
