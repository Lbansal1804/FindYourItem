using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FindYourItem.Models;
using System.Web.Mvc;

namespace FindYourItem.Controllers
{
    public class UserController : Controller
    {

        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post(AdminDetail adminLogin)
        {
            var admin1Login = _context.AdminDetails.Where(x => x.AdminName == adminLogin.AdminName && x.Password == adminLogin.Password).FirstOrDefault();

            if(admin1Login == null)
            {
                return Content("Invalid Data");
            }
            
            return Content("Congratulations");
        }
    }
}