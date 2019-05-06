using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindYourItem.Models;

namespace FindYourItem.Controllers
{
    public class ProductNamesController : Controller
    {
        private ApplicationDbContext _context;

        public ProductNamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            return View("ProductNameForm");
            //var productNames = _context.ProductNames.ToList();
            //var viewModel = new ProductFormViewModel
            //{
              //  ProductNames = productNames
            //};
            //return View("ProductForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(ProductName productName)
        {
    
            if (productName.Id == 0)
                _context.ProductNames.Add(productName);

            else
            {
                var productNameInDb = _context.ProductNames.Single(p => p.Id == productName.Id);
                productNameInDb.Name = productName.Name;

            }
            _context.SaveChanges();
            
            return RedirectToAction("Index", "ProductNames");
        }



        // GET: ProductNames
        public ActionResult Index()
        {
            var productNames = _context.ProductNames.ToList();
            return View(productNames);
        }

        public ActionResult Edit(int id)
        {
            var productNames = _context.ProductNames.SingleOrDefault(p => p.Id == id);

            if (productNames == null)
                return HttpNotFound();

;
            
            return View("ProductNameForm");
        }
    }
}