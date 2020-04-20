using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Morgenmadsbuffet.Models
{
    
    public class RestaurantViewModel
    {
        public List<Bookings> Bookings { get; set; } = new List<Bookings>();

        public int TotalAmountGuests
        {
            get
            {
                var total = 0;
                for (int i = 0; i < Bookings.Count(); i++)
                {
                    total = Bookings[i].AmountAdults + Bookings[i].AmountChildren;
                }

                return total;
            } 
            set
            {

            }
        }
    }
}
