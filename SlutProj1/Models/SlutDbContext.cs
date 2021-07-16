using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlutProj1.Models
{
    public class SlutDbContext : DbContext
    {
        public SlutDbContext(DbContextOptions<SlutDbContext> options) : base(options)
        {

        }

        public DbSet<Tshirt> Tshirts { get; set; }
        public DbSet<Order> Order { get; set; }
       
        public DbSet<ShoppingCartItems> ShoppingCartItems { get; set; }
    }
}
