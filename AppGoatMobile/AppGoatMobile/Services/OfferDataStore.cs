using System.Collections.Generic;
using System.Threading.Tasks;
using AppGoatMobile.Models;
using AppGoatMobile.Repositories;

namespace AppGoatMobile.Services
{
    public class OfferDataStore : IDataStore<Item>
    {
        List<Item> items;
        private OfferRepository _offerRepository;

        public OfferDataStore()
        {
            items = new List<Item>();
           // var current = Connectivity.NetworkAccess;

        }


        public Task<bool> AddItemAsync(Item item)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Item item)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Item> GetItemAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new System.NotImplementedException();
        }
    }
}