using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;

namespace Morgenmadsbuffet.Models
{
    public class ReceptionViewModel
    {
        public List<Bookings> bookings { get; set; }
        public List<DateTime> CheckList { get; set; }

        public int TotalAmountOfGuest { get; set; }

        public int TotalAmountOgChecked { get; set; }

    }
}


