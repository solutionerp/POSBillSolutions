using Microsoft.EntityFrameworkCore;
using POSBill.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.EntityFramework
{
    public class RestaurantRetailPOSBillDBContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<security_roles> security_roles { get; set; }
        public DbSet<stock_master> stock_master { get; set; }
        public DbSet<bank_accounts> bank_accounts { get; set; }
        public DbSet<audit_trail> audit_trail { get; set; }
        public DbSet<areas> areas { get; set; }
        public DbSet<attachments> attachments { get; set; }
        public DbSet<bank_trans> banktrans { get;set; }
        public DbSet<bom> bom { get; set; }
        public DbSet<budget_trans> budgetrans { get; set; }
        public DbSet<chart_class> chart_class { get;set; }
        public DbSet<chart_master> chart_master { get; set; }

        public RestaurantRetailPOSBillDBContext(DbContextOptions options) : base(options){ }

    } 
}
