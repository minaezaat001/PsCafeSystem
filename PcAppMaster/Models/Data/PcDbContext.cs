using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PcAppMaster.Models.Data
{
    public class PcDbContext :DbContext
    {
        public PcDbContext(DbContextOptions<PcDbContext> options) : base(options)
        { }

        public DbSet<Drinks> drinks { get; set; }
        public DbSet<HoursPrice> hoursPrices { get; set; }
        public DbSet<Receipt> receipts { get; set; }
        public DbSet<ReceiptForDrinks> receiptForDrinks { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Device> devices { get; set; }
    }
}
