using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.EntityFramework
{
    public class RestaurantRetailPOSBillDBContextFactory : IDesignTimeDbContextFactory<RestaurantRetailPOSBillDBContext>
    {
        public RestaurantRetailPOSBillDBContext CreateDbContext(string[] args = null)
        {
            var options =new DbContextOptionsBuilder<RestaurantRetailPOSBillDBContext>();
            options.UseMySQL("Server=localhost;Database=RRPOSDB;Uid=root;Pwd=1234");

            return new RestaurantRetailPOSBillDBContext(options.Options);
        }
    }
}
