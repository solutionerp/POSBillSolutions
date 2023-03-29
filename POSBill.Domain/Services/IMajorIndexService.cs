using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.Domain.Services
{
    public interface IMajorIndexService
    {
        Task<String> Authenticate(string username, string password);
    }
}
