using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Android.OS;
using AppGoatMobile.Constants;

namespace AppGoatMobile.Services
{
    public class AppService
    {

        public async Task LoginAsync(string username, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type","password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, $"http://GoatApi.somee.com/Token")
            {
                Content = new FormUrlEncodedContent(keyValues)
            };

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = response.Content.ReadAsStringAsync();
        }
    }
}