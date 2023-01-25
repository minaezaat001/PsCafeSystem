using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PcAppMaster.Models;
using PcAppMaster.Models.Data;

namespace PcAppMaster.Controllers
{
    public class LoginController : Controller
    {
        private readonly PcDbContext db;

        public LoginController(PcDbContext db)
        {
            this.db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var usser = db.users.Where(u => u.UserName == user.UserName && u.UserPassword == u.UserPassword).FirstOrDefault();
            if (usser != null) 
            {
                if (usser.UserKind== "Admin" ) 
                {
                   return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else 
            {
                ViewBag.log = "Wrong User Or Password";
              
            }
              return View();

        }
    }
}