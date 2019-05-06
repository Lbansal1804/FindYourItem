using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindYourItem.Models;
using FindYourItem.ViewModels;
using System.Data.Entity;

namespace FindYourItem.Controllers
{
    public class ProductDetailsController : Controller
    {

        private ApplicationDbContext _context;

        public ProductDetailsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var productNames = _context.ProductNames.ToList();
            var viewModel = new ProductFormViewModel
            {
                ProductDetails = new ProductDetails(),
                ProductNames = productNames
            };
            return View("ProductForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(ProductDetails productDetails)
        {
           if (!ModelState.IsValid)
            {
                var viewModel = new ProductFormViewModel
                {
                    ProductDetails = productDetails,
                    ProductNames = _context.ProductNames.ToList()
                };
                return View("ProductForm", viewModel);
            }

                if (productDetails.Id == 0)
                    _context.ProductDetails.Add(productDetails);

                else
                {
                    var productDetailsInDb = _context.ProductDetails.Single(p => p.Id == productDetails.Id);

                    productDetailsInDb.Name = productDetails.Name;
                    productDetailsInDb.Price = productDetails.Price;
                    productDetailsInDb.Quantity = productDetails.Quantity;
                    productDetailsInDb.Location = productDetails.Location;
                    productDetailsInDb.AisleNumber = productDetails.AisleNumber;
                    productDetailsInDb.ProductNameId = productDetails.ProductNameId;

                }

            
            
            _context.SaveChanges();
            return RedirectToAction("Index", "ProductDetails");
        }



        // GET: ProductDetails
        public ActionResult Random()
        {
            var productDetails = new ProductDetails()
            {
                Name = "Apple"
            };

            return View(productDetails);
        }

        public ViewResult Index()
        {
            var productDetails = _context.ProductDetails.Include(p => p.ProductName).Include(p => p.AdminDetail).ToList();
            return View(productDetails);
        }

        public ActionResult Details(int id)
        {
            var productDetail = _context.ProductDetails.SingleOrDefault(p => p.Id == id);
            if (productDetail == null)
                return HttpNotFound();

            return Json(productDetail);
        }


        public ActionResult Get(ProductDetails userId)
        {
            return Json(userId);
        }

         public ActionResult Edit(int id)
        {
            var productDetails = _context.ProductDetails.SingleOrDefault(p => p.Id == id);

            if (productDetails == null)
                return HttpNotFound();

            var viewModel = new ProductFormViewModel
            {
                ProductDetails = productDetails,
                ProductNames = _context.ProductNames.ToList()
            };

            return View("ProductForm", viewModel);
        }
    }
}