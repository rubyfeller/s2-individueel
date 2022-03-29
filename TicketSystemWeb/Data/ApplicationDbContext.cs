using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketSystemWeb.Models;

namespace TicketSystemWeb.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TicketViewModel> Tickets { get; set; }
        public DbSet<DeviceViewModel> Devices { get; set; }

    }
}