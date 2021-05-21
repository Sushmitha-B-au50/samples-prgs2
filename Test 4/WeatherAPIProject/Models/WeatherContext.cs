using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPIProject.Models
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Weather> Weathers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weather>().HasData(
                new Weather() { City="chennai",Date=DateTime.Now,HighTemperature=32,LowTemperature=17 ,Forcast="sunny"}
                );

        }
    }
}
