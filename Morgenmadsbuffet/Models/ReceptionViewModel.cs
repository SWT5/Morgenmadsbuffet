using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffet.Models
{
    public class ReceptionViewModel
    {
        public int TotalOrders { get; set; }
        public List<Rooms> RoomNumbers { get; set; }
        public DateTime Date { get; set; }

    }
}
