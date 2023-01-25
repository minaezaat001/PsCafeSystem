using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcAppMaster.Models;
using PcAppMaster.Models.Data;

namespace PcAppMaster.Controllers
{
    public class AdminController : Controller
    {
        private readonly PcDbContext db;

        public AdminController (PcDbContext db) 
        {
            this.db = db;
        }

                     
        public ActionResult Index () 
        {

            return View();

        }


        // GET: Drinks
        public List<Drinks> IndexDrink()
        {
            var drink = db.drinks.ToList();
            return drink;
        }

        // GET: Drinks/Create
        public ActionResult CreateDrink()
        {
            return View();
        }

        // POST: Drinks/Create
        [HttpPost]
        public void CreateDrink(Drinks drink)
        {

            db.drinks.Add(drink);
            db.SaveChanges();
        }

        // GET: Drinks/Edit/5
        public Drinks EditDrink(int id)
        {
            var drink = db.drinks.Find(id);
            return drink;
        }

        // POST: Drinks/Edit/5
        [HttpPost]
        public void EditDrink(int id, Drinks drink)
        {
            db.drinks.Update(drink);
            db.SaveChanges();
         
        }

        // GET: Drinks/Delete/5
        public void DeleteDrink(int id)
        {
            var drink = db.drinks.Find(id);
            db.drinks.Remove(drink);
            db.SaveChanges();
        }



        public Drinks Search(int id)
        {
            return db.drinks.Where(d => d.DrDrinkId == id).FirstOrDefault();
        }

        // GET: Device
        public List<Device> IndexDevice()
        {

            var dev = db.devices.Include(f=>f.HoursPrice ).ToList();
            return dev;
           
        }



        // GET: Device/Create
        public ActionResult CreateDevice()
        {
            return View();
        }

        // POST: Device/Create
        [HttpPost]

        public void CreateDevice(Device device)
        {
            db.devices.Add(device);
            db.SaveChanges();
        }

        // GET: Device/Edit/5
        public Device EditDevice(int id)
        {
            Device dev = db.devices.Find(id);
            return dev;
        }

        // POST: Device/Edit/5
        [HttpPost]
        public void EditDevice(int id, Device device)
        {
           
                db.devices.Update(device);
                db.SaveChanges();
        }

        // GET: Device/Delete/5
        public void DeleteDevice(int id)
        {
            Device device = db.devices.Find(id);
            db.devices.Remove(device);
            db.SaveChanges();
        }
        // Shift by Today
        public List<Receipt> ShiftToday() 
        {
            var rec = db.receipts.Where(r => r.RecReceiptDate == DateTime.Today).ToList();
            ViewBag.totaltoday=rec.Sum(f => f.RecTotal);
            return rec;

        }

        // 
        public double ShiftTodayforlable()
        {
            var rec = db.receipts.Where(r => r.RecReceiptDate == DateTime.Today).ToList();
            var to = Math.Round(rec.Sum(f => f.RecTotal),2);
            return to;

        }



        //Shift between two date 
        public List<Receipt> DateTaker(DateTime From, DateTime To)
        {
            var rec = db.receipts.Where(e => e.RecReceiptDate >= From && e.RecReceiptDate <= To).ToList();
            ViewBag.totaldatetaker = rec.Sum(f => f.RecTotal);
            return rec;
        }
        public double DateTakerforlable(DateTime From, DateTime To)
        {
            var rec = db.receipts.Where(e => e.RecReceiptDate >= From && e.RecReceiptDate <= To).ToList();
            var to = Math.Round(rec.Sum(f => f.RecTotal), 2);
            return to;
        }



        // GET: HourePrice
        public List<HoursPrice> IndexHoursPrice()
        {
            var HP = db.hoursPrices.ToList();
            return HP;
        }


        // GET: HourePrice/Create
        public ActionResult CreateHoursPrice()
        {
            return View();
        }

        // POST: HourePrice/Create
        [HttpPost]
        public void CreateHoursPrice(HoursPrice hoursPrice)
        {
            db.hoursPrices.Add(hoursPrice);
            db.SaveChanges();
        }

        // GET: HourePrice/Edit/5
        public HoursPrice EditHoursPrice(int id)
        {
            var hp = db.hoursPrices.Find(id);
            return hp;
        }

        // POST: HourePrice/Edit/5
        [HttpPost]

        public void EditHoursPrice(int id, HoursPrice hoursPrice)
        {
            db.hoursPrices.Update(hoursPrice);
            db.SaveChanges();
        }

        // GET: HourePrice/Delete/5
        public void DeleteHoursPrice(int id)
        {
            var hp = db.hoursPrices.Find(id);
            db.hoursPrices.Remove(hp);
            db.SaveChanges();
        }
        // Areas
        // Count Device Online 
        public int Devonline () 
        {
            var rec = db.receipts.Where(r => r.RecStartTime != null && r.RecTotal == 0).ToList();
            var pc = rec.Count;
            return pc;
            
        }
        // Total Today
        public double TotalToday () 
        {
         var rec = ShiftToday();
         var total = rec.Sum(h => h.RecTotal);
          return total;
        }
    }
}