using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;


namespace Catalog.Repositories
{
    public interface IItemsRepository //used to be public class InMemItemsRepository{}
    {
        //Task is represents an asynchronous operation
        // Item GetItem(Guid id);
        // IEnumerable<Item> GetItems();
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();

        Task CreateItemAsync(Item item);//return nothing, just received that needs to be created

        Task UpdateItemAsync(Item item);

        Task DeleteItemAsync(Guid id);
    }
}