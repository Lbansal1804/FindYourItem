using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Data.Entity;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace FindYourItem.Models
{
    public class ApplicationUser : IdentityUser
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }



    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<ProductName> ProductNames { get; set; }

        public DbSet<AdminDetail> AdminDetails { get; set; }
        public ApplicationDbContext()
            : base("FindYourItemDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }





}