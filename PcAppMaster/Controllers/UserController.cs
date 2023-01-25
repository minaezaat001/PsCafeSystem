using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PcAppMaster.Models;
using PcAppMaster.Models.Data;

namespace PcAppMaster.Controllers
{
    public class UserController : Controller
    {
        private readonly PcDbContext db;

        public UserController(PcDbContext db)
        {
            this.db = db;
        }
        // GET: User
        public List<User> IndexUser()
        {
            var user = db.users.ToList();
            return user;
        }

        // GET: User/Create
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public void CreateUser(User user)
        {
            db.users.Add(user);
            db.SaveChanges();
        }

        // GET: User/Edit/5
        public User EditUser(int id)
        {
            var user = db.users.Find(id);
            return user;
        }

        // POST: User/Edit/5
        [HttpPost]

        public void EditUser(int id, User user)
        {
            db.users.Update(user);
            db.SaveChanges();
        }

        // GET: User/Delete/5
        public void DeleteUser(int id)
        {
            var user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
        }


    }
}
