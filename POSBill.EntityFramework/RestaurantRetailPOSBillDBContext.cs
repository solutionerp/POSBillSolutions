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
            optionsBuilder.UseMySQL("Server=localhost;Database=RRDB;Uid=root;Pwd=1234");
            base.OnConfiguring(optionsBuilder);
        }
    } 
}
