using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffet.Models
{
    public class KitchenViewModel
    {
        public List<Bookings> bookings { get; set; }
        public List<DateTime> CheckList { get; set; }

        public DateTime SearchDate { get; set; }

        public int TotalAmountOfGuest { get; set; }

        public int TotalAmountOfChecked { get; set; }

    }
}
