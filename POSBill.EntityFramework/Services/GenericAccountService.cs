using POSBill.Domain.Models;
using POSBill.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.EntityFramework.Services
{
    public class GenericAccountService<T> : IAccountServices<T> where T : DomainObject
    {
        public Task<String> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
