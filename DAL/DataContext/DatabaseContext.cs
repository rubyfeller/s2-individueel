using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                OptionsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = OptionsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }

        }
        public static OptionsBuild options = new OptionsBuild();


        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Device> Devices { get; set; }
        //public DbSet<Authentication> Authentication { get; set; }
    }
}
