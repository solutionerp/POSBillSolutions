﻿using Microsoft.EntityFrameworkCore;
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
        public RestaurantRetailPOSBillDBContext(DbContextOptions options) : base(options){ }

    } 
}
