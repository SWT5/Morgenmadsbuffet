using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffet.Models
{
    public class Rooms
    {
        [Key]
        public int RoomNumber { get; set; }

        public int AmountChildren { get; set; }

        public int AmountAdults { get; set; }




    }
}
