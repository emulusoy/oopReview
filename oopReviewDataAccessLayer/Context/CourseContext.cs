using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oopReviewEntityLayer.Concrete;

namespace oopReviewDataAccessLayer.Context
{
    public class CourseContext:DbContext
    {
        //Bunlari kullanmak icin referans vermelisin!
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
