using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Context
{
    public class KalmyContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public KalmyContext(DbContextOptions options, IConfiguration configration) : base(options)
        {
            _configuration = configration;
        }

        public DbSet<Api.Data.Entities.Car> Car { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Kalmy"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Car>()
            //    .HasData(new
            //    {
            //        Id = 1,
            //        Type = "",
            //        Brand = "Funny Comedy Night",
            //        Model = 2020,
            //        CreationUser = -1,
            //        ModificationUser = -1,
            //        CreatedAt = DateTime.Now,
            //        ModifiedAt = DateTime.Now
            //    });



        }
    }
}
