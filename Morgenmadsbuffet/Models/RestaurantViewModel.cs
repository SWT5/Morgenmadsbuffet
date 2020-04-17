using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffet.Models
{
    
    public class RestaurantViewModel
    {
        public List<Bookings> Bookings { get; set; }

        //public int TotalAmountGuests { get; set; }
        //public int RoomNumber { get; set; }
        //public int AmountAdults { get; set; }
        //public int AmountChildren { get; set; }

        public bool Checkedin
        {
            get;
            set;
        }
    }
}
