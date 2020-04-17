using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffet.Data;
using Morgenmadsbuffet.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Morgenmadsbuffet.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceptionController(ApplicationDbContext context)
        {
            _context = context;
        }


        //[Authorize("IsReceptionist")]
        // GET: /<controller>/  // virker ikke
        public IActionResult HaveBooked()
        {
            return View("../Bookings/Index");
        }

        //[Authorize("IsReceptionist")]
        public IActionResult Create()
        {
            return View("../Bookings/Create");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .FirstOrDefaultAsync(m => m.RoomNumber == id);
            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }
    }
}

