using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using POSBill.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordVerificationResult = Microsoft.AspNet.Identity.PasswordVerificationResult;

namespace POSBill.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountServices _accountService;

        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountServices accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public Task<User> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        //public async Task<User> Login(string username, string password)
        //{
        //    User storedAccount = await _accountService.GetByUsername(username);
        //    PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.passwordHash, password);
        //    if(passwordResult != PasswordVerificationResult.Success) 
        //    {
        //        throw new Exception();
        //    }
        //    return storedAccount;
        //}
    }
}
