using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGoatMobile.Models;
using AppGoatMobile.Repositories;
using Xamarin.Essentials;

namespace AppGoatMobile.Services
{
    public class OfferDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        private readonly OfferRepository _offerRepository;

        public OfferDataStore()
        {
            items = new List<Item>();
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                _offerRepository = new OfferRepository();
                var offers = _offerRepository.GetOffers(1);

                foreach (var offer in offers)
                {
                    items.Add(new Item
                    {
                        Id = offer.Id.ToString(),
                        Text = offer.Name,
                        Description = offer.Description,
                        Color = offer.ColorCode,
                        IsActive = false
                    });
                }
            }
        }


        public async Task<bool> AddItemAsync(Item item)
        {
            _offerRepository.Add(item);
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.FirstOrDefault(arg => arg.Id == item.Id);
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.FirstOrDefault(arg => arg.Id == id);
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}