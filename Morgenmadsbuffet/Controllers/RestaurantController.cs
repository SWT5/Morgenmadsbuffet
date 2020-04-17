using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Morgenmadsbuffet.Controllers
{
    public class RestaurantController : Controller
    {
        [Authorize("IsRestaurant")]
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("../Bookings/index");
        }

        public IActionResult Edit()
        {
            return View("../Bookings/Edit");
        }
    }
}
