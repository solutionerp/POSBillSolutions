﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Models
{
    public class User : DomainObject
    {
      

        public string username { get; set; }
        public string password { get; set; }    
    }
}
