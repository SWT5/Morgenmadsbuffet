using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffet.Data;
using Morgenmadsbuffet.Models;

namespace Morgenmadsbuffet.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bookings.ToListAsync());
        }

        // GET: Bookings/Details/5
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

        // GET: Bookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomNumber,Date,Checkedin,AmountAdults,AmountChildren")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookings);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings.FindAsync(id);
            if (bookings == null)
            {
                return NotFound();
            }
            return View(bookings);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomNumber,Date,Checkedin,AmountAdults,AmountChildren")] Bookings bookings)
        {
            if (id != bookings.RoomNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingsExists(bookings.RoomNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookings);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookings = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(bookings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingsExists(int id)
        {
            return _context.Bookings.Any(e => e.RoomNumber == id);
        }


        // ****************** Recetion part *************************

        // GET: Bookings reception
        public async Task<IActionResult> ReceptionMain()
        {
            var vm = new ReceptionViewModel();
            var bookings = from b in _context.Bookings select b;
            

            vm.bookings = await bookings.ToListAsync();
            //foreach (var booking in bookings)
            //{
            //    vm.TotalAmountOfGuest += booking.AmountAdults + booking.AmountChildren;
            //}
            return View(vm);
        }


        public async Task<IActionResult> ReceptionCheckedIn(DateTime searchDate)
        {
            var vm = new ReceptionViewModel();

            var bookings = from b in _context.Bookings select b;
            
            var CheckinQuery = from c in _context.Bookings select c.Date.Date;


            vm.CheckList= await CheckinQuery.Distinct().ToListAsync();

            if (CheckinQuery != null)
            {
                bookings = bookings.Where(c => c.Date.Date.Equals(searchDate.Date));
            }
            vm.bookings = await bookings.ToListAsync();

            foreach (var booking in bookings)
            {
                if (booking.Checkedin == true)
                {
                    vm.TotalAmountOgChecked += booking.AmountAdults + booking.AmountChildren;
                }
                vm.TotalAmountOfGuest += booking.AmountAdults + booking.AmountChildren;
            }

            return View(vm);
        }


        // GET: Bookings/Create
        public IActionResult NewBooking()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewBooking([Bind("RoomNumber,Date,Checkedin,AmountAdults,AmountChildren")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ReceptionMain));
            }
            return View(bookings);
        }

        
        //***********************Resturant part ****************************************


        public async Task<IActionResult> RestaurantMain()
        {
            var bookings = from b in _context.Bookings select b;
            var vm = new RestaurantViewModel();
            vm.Bookings = await _context.Bookings.ToListAsync();
            foreach (var booking in bookings)
            {
                if (booking.Checkedin == true)
                {
                    vm.TotalAmountGuests += booking.AmountAdults + booking.AmountChildren;
                }

            }
            _context.SaveChanges();
            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> RestaurantMain(RestaurantViewModel model)
        {

            var vm = new RestaurantViewModel();
            var bookings = from b in _context.Bookings select b;
            vm.Bookings = await _context.Bookings.ToListAsync();

            for (int i = 0; i < model.Bookings.Count(); i++)
            {
                vm.Bookings[i].Checkedin = model.Bookings[i].Checkedin;
            }
            foreach (var booking in bookings)
            {
                if (booking.Checkedin == true)
                {
                    vm.TotalAmountGuests += booking.AmountAdults + booking.AmountChildren;
                }

            }
            _context.SaveChanges();
            return View(vm);

        }




        //************************ Kitchen **************************************************
        // GET: Bookings kitchen
        public async Task<IActionResult> Kitchen(DateTime searchDate)
        {
            var vm = new KitchenViewModel();
            var bookings = from b in _context.Bookings select b;
            

            vm.bookings = await bookings.ToListAsync();
            //foreach (var booking in bookings)
            //{
            //    vm.TotalAmountOfGuest += booking.AmountAdults + booking.AmountChildren;
            //}
            var CheckinQuery = from c in _context.Bookings select c.Date.Date;


            vm.CheckList= await CheckinQuery.Distinct().ToListAsync();

            if (CheckinQuery != null)
            {
                bookings = bookings.Where(c => c.Date.Date.Equals(searchDate.Date));
            }
            vm.bookings = await bookings.ToListAsync();

            foreach (var booking in bookings)
            {
                if (booking.Checkedin == true)
                {
                    vm.TotalAmountOfChecked += booking.AmountAdults + booking.AmountChildren;
                }
                vm.TotalAmountOfGuest += booking.AmountAdults + booking.AmountChildren;
            }

            return View(vm);
        }
    }
}
