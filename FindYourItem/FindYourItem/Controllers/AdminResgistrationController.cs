using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindYourItem.Models;

namespace FindYourItem.Controllers
{
    public class AdminResgistrationController : Controller
    {

        private ApplicationDbContext _context;

        public AdminResgistrationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        // GET: AdminResgistration
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Save(AdminDetail adminDetail)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            if (_context.AdminDetails.Any(x => x.StoreId == adminDetail.StoreId))
            {
                ViewBag.DuplicateMessage = "Store ID Already exists";
                return View("Index");
            }

            if (adminDetail.Id == 0)
                _context.AdminDetails.Add(adminDetail);

            else
            {
                var adminDetailInDb = _context.AdminDetails.Single(p => p.Id == adminDetail.Id);
                adminDetailInDb.Location = adminDetail.Location;
                adminDetailInDb.Password = adminDetail.Password;
                adminDetailInDb.StoreId = adminDetail.StoreId;
                adminDetailInDb.Username = adminDetail.Username;
                adminDetailInDb.AdminName = adminDetail.AdminName;
                adminDetailInDb.EmailAddress = adminDetail.EmailAddress;

            }
                _context.SaveChanges();
           
            
            return Content("Congratulations");
            
        }



    }
}