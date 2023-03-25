using POSBill.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<User>Login(string username,string password);
    }
}
