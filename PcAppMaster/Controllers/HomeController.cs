using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PcAppMaster.Models;
using PcAppMaster.Models.Data;
using PcAppMaster.Models.ViewModel;

namespace PcAppMaster.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PcDbContext db;

        public HomeController(ILogger<HomeController> logger, PcDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public ActionResult Index()
        {
           
            ViewBag.types = db.hoursPrices.ToList();
            var dev = db.devices.ToList();
            return View(dev);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //button start
        public void StartTime(int id, bool SorM)
        {
            Receipt receipt = new Receipt();
            receipt.RecStartTime = DateTime.Now;
            receipt.RecPcName = id.ToString();
            receipt.RecHoursType = SorM;
            db.receipts.Add(receipt);
            db.SaveChanges();
        }

        // ReceiptForDrinks Create

        public ActionResult AddDrink()
        {
            var model = new DrinkReceiptForDrinksViewModel
            {
                Drinks = db.drinks.ToList()
            };
            return View(model);
        }

        // POST: ReceiptForDrinks/Create
        [HttpPost]
        public ActionResult AddDrink(DrinkReceiptForDrinksViewModel receiptfordrinks, string id)
        {
            List<Receipt> Lreceipt = db.receipts.Where(x => x.RecPcName == id).ToList();
            var receipt = Lreceipt.Last();
            receiptfordrinks.BillId = receipt.BillId;
            var drinklist = db.drinks.Find(receiptfordrinks.DrinkId);
            ReceiptForDrinks receiptFor = new ReceiptForDrinks
            {
                BillId = receiptfordrinks.BillId,
                RfDrink = drinklist.DrDrinkName,
                RfDrinkId = receiptfordrinks.RfDrinkId,
                RfDrinkprice = drinklist.DrDrinkPrice,
                RfDrinkQut = receiptfordrinks.RfDrinkQut,
                drinks = drinklist
            };
            receiptFor.RfDrinkTotal = receiptFor.RfDrinkQut * receiptFor.RfDrinkprice;
            var drinks = db.drinks.Where(d => d.DrDrinkName == receiptFor.RfDrink).FirstOrDefault();
            drinks.DrDrinkQut = drinks.DrDrinkQut - receiptFor.RfDrinkQut;
            db.receiptForDrinks.Add(receiptFor);
            db.SaveChanges();
            return RedirectToAction("AddDrink");
        }
        //button details
        public ActionResult Details( string id)
        {
            List<Receipt> Lreceipt = db.receipts.Where(x => x.RecPcName == id).ToList();
            var receipt = Lreceipt.Last();
            ViewBag.pc = receipt.RecPcName;
            var rs = db.receiptForDrinks.Where(s => s.BillId == receipt.BillId);
            ViewBag.listofdrinks = rs.ToList();
            var sd = rs.Sum(f => f.RfDrinkTotal);
            receipt.RecReceiptDate = DateTime.Today;
            receipt.RecEndTime = DateTime.Now;
            var totalmin = receipt.RecTotalMinutes = (int)(receipt.RecEndTime - receipt.RecStartTime).TotalMinutes;
            var dev = db.devices.Where(d => d.DvNumber == id).SingleOrDefault();
            var hoursprice = db.hoursPrices.Where(d => d.HpId == dev.HpId).SingleOrDefault();
            var x = hoursprice.HpSinglePrice / 60;
            var y = hoursprice.HpMultiPrice / 60;
            var single= Math.Round(x,2);
            var multi = Math.Round(y, 2);
            if (receipt.RecHoursType == true)
            {
                receipt.RecHoursPrice = totalmin * multi;
                receipt.RecHoursType = true;
            }

            else
            {
                receipt.RecHoursPrice = totalmin * single;
                receipt.RecHoursType = false;
            }

            receipt.RecDrinkPrice = sd;
            receipt.RecTotal = receipt.RecHoursPrice + receipt.RecDrinkPrice;
            return View(receipt);
        }

        //button End

        public void end(string id)
        {
            Details(id);
            db.SaveChanges();
        }

        

    }

}


