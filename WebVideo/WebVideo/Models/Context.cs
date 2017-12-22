using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebVideo.Models
{
    public class Context : DbContext
    {
        public Context() :
            base("DefaultConnection")
        { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Photos> Photo { get; set; }
        public DbSet<Videos> Video { get; set; }    

        
    }
}