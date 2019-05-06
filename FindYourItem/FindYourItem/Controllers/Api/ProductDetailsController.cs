using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FindYourItem.Models;
using System.Web.Http.Cors;
using AutoMapper;
using FindYourItem.Dtos;

namespace FindYourItem.Controllers.Api
{
    public class ProductDetailsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductDetailsController()
        {
            _context = new ApplicationDbContext();
        }



        [System.Web.Http.HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

        // GET api/productdetails
        //public IEnumerable<ProductDetailDto> GetProductDetails()
        //{
        //    return _context.ProductDetails.ToList().Select(Mapper.Map<ProductDetails, ProductDetailDto>);
        //}

        public IHttpActionResult ShowProductAccToUser(string userName)
        {
            var admin = _context.AdminDetails.Select(selector: Mapper.Map<AdminDetail, AdminDetailDto>).Where(x => x.Username == userName).First();

            var prodcuts = _context.ProductDetails.Where(product => admin.Id == product.AdminDetail.Id).ToList();
            return Ok(prodcuts);
        }

        [System.Web.Http.HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        //GET api/productdetails/1
        public IHttpActionResult GetProductDetail(int id)
        {
            var productDetail = _context.ProductDetails.SingleOrDefault(p => p.Id == id);

            if (productDetail == null)
                return NotFound();

            return Ok(Mapper.Map<ProductDetails, ProductDetailDto>(productDetail));
        }

        [System.Web.Http.HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        //GET: Product Details based on Search
        public IHttpActionResult ShowProductOnSearch(string productName, string loCation )
        {
            var produce = _context.ProductDetails.Select(selector: Mapper.Map<ProductDetails, ProductDetailDto>).Where(x => x.Name.ToLower() == productName.ToLower() && x.Location.ToLower() == loCation.ToLower());

            if (produce == null)
                return NotFound();

            return Ok(produce.Select(p => new { p.Location, p.Name, p.AdminDetailStoreId }));
        }


        [System.Web.Http.HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        //GET: Show Aisle Number based on StoreId Details
        public IHttpActionResult ShowAisleNumber(string productName, string loCation, int storeId)
        {
            var produce = _context.ProductDetails.Select(selector: Mapper.Map<ProductDetails, ProductDetailDto>).Where(x => x.Name == productName && x.Location == loCation && x.AdminDetailStoreId == storeId);

            if (produce == null)
                return NotFound();

            return Ok(produce.Select(p => new { p.Name, p.AisleNumber }).ToList()[0]);
        }








        //POST api/productdetails   CREATE
        [System.Web.Http.HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpPost]
        public IHttpActionResult CreateProductDetail([FromBody]ProductDetailDto productDetailsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productDetails = Mapper.Map<ProductDetailDto, ProductDetails>(productDetailsDto);

            _context.ProductDetails.Add(productDetails);
            _context.SaveChanges();

            productDetailsDto.Id = productDetails.Id;

            return Created(new Uri(Request.RequestUri + "/" + productDetails.Id), productDetailsDto);
        }


        //PUT api/productdetails/1
        [System.Web.Http.HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpPut]
        public void UpdateProductDetail(int id, ProductDetailDto productDetailsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var productDetailsInDB = _context.ProductDetails.SingleOrDefault(p => p.Id == id);

            if (productDetailsInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(productDetailsDto, productDetailsInDB);
           

            _context.SaveChanges();




        }



        //DELETE api/productdetails/1
        [System.Web.Http.HttpDelete]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        
        public void DeleteProductDetail(int id)
        {

            var productDetailsInDB = _context.ProductDetails.SingleOrDefault(p => p.Id == id);

            if (productDetailsInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.ProductDetails.Remove(productDetailsInDB);
            _context.SaveChanges();


        }




    }
}
