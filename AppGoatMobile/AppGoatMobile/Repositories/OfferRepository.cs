using System;
using System.Collections.Generic;
using System.Net.Http;
using AppGoatMobile.Constants;
using AppGoatMobile.Models;
using Newtonsoft.Json;

namespace AppGoatMobile.Repositories
{
    public class OfferRepository
    {
        public OfferRepository()
        {
        }

        public List<Offer> GetOffers(int page)
        {
            List<Offer> offers = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebServicesValues.URL_API);
                var responseTask = client.GetAsync("offerapi");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var response = result.Content.ReadAsStringAsync().Result;
                    offers = JsonConvert.DeserializeObject<List<Offer>>(response);
                }
            }

            return offers;
        }

        public Offer GetOfferById(object id)
        {

            return null;
        }

        public void Add(Item item)
        {
            using (var client = new HttpClient())
            {
                var offer = new Offer
                {
                    Name = item.Text,
                    Description = item.Description,
                    ColorCode = item.Color
                };

                client.BaseAddress = new Uri(WebServicesValues.URL_API);
                var postTask = client.PostAsJsonAsync($"{WebServicesValues.URL_API}/offerapi", offer);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("OK");
                }
            }
        }
    }
}