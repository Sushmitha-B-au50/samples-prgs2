using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameSecondApproach
{
    class EFContext : DbContext
    {
       public EFContext()
        {

        }

        private const string connectionString = @"Server=DESKTOP-8DSBI98\SQLEXPRESS;Database=EFCore;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
   
}
