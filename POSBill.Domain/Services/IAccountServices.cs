﻿using POSBill.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Services
{
    public interface IAccountServices<T>
    {
        Task<User> GetByUsername(string username);
       
    }
}
