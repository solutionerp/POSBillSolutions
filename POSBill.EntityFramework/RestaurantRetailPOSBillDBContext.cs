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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server.\\DESKTOP-LETTAVT;Database=RRDB;");
            base.OnConfiguring(optionsBuilder);
        }
    } 
}
