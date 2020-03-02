using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace itwazzup.Persistence.Context {
    public class itwazzupDbContextFactory : IDesignTimeDbContextFactory<itwazzupDbContext> {
        public static IConfigurationRoot Configuration { get; set; }
        public itwazzupDbContextFactory () {
            var builder = new ConfigurationBuilder ()
                .SetBasePath (Directory.GetCurrentDirectory ())
                .AddJsonFile ("appsettings.json");
            Configuration = builder.Build ();
        }
        public itwazzupDbContext CreateDbContext (string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<itwazzupDbContext> ();
            optionsBuilder.UseSqlServer (Configuration.GetConnectionString ("Default"));
            return new itwazzupDbContext (optionsBuilder.Options);
        }
    }
}