using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GlobalSoft.Models
{
    public class GlobalDbContext : DbContext
    {
        public DbSet<AptType> AptTipes { get; set; }
        public DbSet<AptCategorie> AptCategories { get; set; }
        public DbSet<AptUnit> AptUnits { get; set; }
        public DbSet<AptStatus> AptStatuses { get; set; }
        public DbSet<AptAgen> AptAgens { get; set; }
        public DbSet<AptMarketing> AptMarketings { get; set; }
        public DbSet<AptPayment> AptPayments { get; set; }
        public DbSet<AptTrans> AptTranss { get; set; }
        public DbSet<AptTrsNo> AptTrsNo { get; set; }
        public DbSet<ArCustomer> ArCustomers { get; set; }
    }

}