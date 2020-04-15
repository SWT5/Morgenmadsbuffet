using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffet.Models
{
    public class Bookings
    {
        public int RoomNumber { get; set; }
        public DateTime Date { get; set; }
        public bool Checkedin { get; set; }
        public int AmountAdults { get; set; }
        public int AmountChildren { get; set; }

    }
}
