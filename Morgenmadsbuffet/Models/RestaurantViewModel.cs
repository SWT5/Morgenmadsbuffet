using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Morgenmadsbuffet.Models
{
    
    public class RestaurantViewModel
    {
        //private int total;
        public List<Bookings> Bookings { get; set; } = new List<Bookings>();
        public DateTime Date { get; set; }
        public int TotalAmountGuests { get; set; }

        //public int TotalAmountGuests
        //{
            
        //    get => total;
        //    set
        //    {
        //        for (int i = 0; i < Bookings.Count(); i++)
        //        {
        //            total = Bookings[i].AmountAdults + Bookings[i].AmountChildren;
        //        }
        //    }
        //}
    }
}
