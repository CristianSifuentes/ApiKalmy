using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Api.Data.EF
{
    class KalmyContext : DbContext
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
    }
    
}
