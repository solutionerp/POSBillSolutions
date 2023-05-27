using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class Cart
    {
        public Customer custmerCart;
        public User userCart;
        public PosBillDetails[] posBillArray;
    }
}
