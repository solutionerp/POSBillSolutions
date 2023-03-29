using POSBill.Domain.Models;
using POSBill.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailResuarantPOSAPI.Api.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<String> Authenticate(string username, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(new[] {
            new KeyValuePair<string, string>("username", username),
            new KeyValuePair<string, string>("password", password)
        });

                var response = await httpClient.PostAsync("http://192.168.0.223/lab/qcc2/modules/mpos_r/api/v3/auth/login", requestContent);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"Authentication failed: {response.StatusCode}");
                }
            }
        }
    }
}

