using FindYourItem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using FindYourItem.Dtos;

namespace FindYourItem.Controllers.Api
{
    public class AdminResgistrationController : ApiController
    {
        private ApplicationDbContext _context;

        public AdminResgistrationController()
        {
            _context = new ApplicationDbContext();
        }



        [System.Web.Http.HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        // GET api/adminresgistration
        //public IHttpActionResult LoginAdmin(AdminDetailDto adminDetailsDto)
        public IHttpActionResult GetProductsByAdmin(AdminDetailDto adminDetailsDto)
        {

            if (_context.AdminDetails.Any(x => x.Username == adminDetailsDto.Username))
            {
                var admin = _context.AdminDetails.Select(selector: Mapper.Map<AdminDetail, AdminDetailDto>).Where(x => x.Username == adminDetailsDto.Username).SingleOrDefault();

                var prodcuts = _context.ProductDetails.Where(product => admin.Id == product.AdminDetail.Id).ToList();

                return Ok(prodcuts);
            }



            return NotFound();
            //else
            //{
            //    return Ok("Chl Cutiyeeeee");

            //}

        }




        [System.Web.Http.HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public IHttpActionResult loginAdmin(string userName, string password)
        {
            var admin = _context.AdminDetails.Select(selector: Mapper.Map<AdminDetail, AdminDetailDto>).Where(x => x.Username == userName && x.Password == password);

            if (!admin.Any()) return NotFound();

            return Ok(admin.First());
        }





        [System.Web.Http.HttpPost]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

        public IHttpActionResult CreateAdminDetail(AdminDetailDto adminDetailsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_context.AdminDetails.Any(x => x.StoreId == adminDetailsDto.StoreId))
            {
                return Ok("Store Id already exists.");
            }
            var adminDetails = Mapper.Map<AdminDetailDto, AdminDetail>(adminDetailsDto);

                _context.AdminDetails.Add(adminDetails);
                _context.SaveChanges();
               
               adminDetailsDto.Id = adminDetails.Id;
               return Created(new Uri(Request.RequestUri + "/" + adminDetails.Id), adminDetailsDto);
        }
    }
}
