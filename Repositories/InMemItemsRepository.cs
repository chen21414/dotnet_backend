using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{

    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new() //= new List(Item)
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow},
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow},
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            //return items; //return whatever we have now
            return await Task.FromResult(items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            //return items.Where(item => item.Id == id).SingleOrDefault(); //we dont wnat return a collection, so use SingleOrDefault here
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            //the only thing we have to return is some sort of task
            //create some task that is already completed and return it, w/o returning anything inside it
            //because nothing to return
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            //find the relevant item and update it
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}


// What is the purpose of readonly?
// Read-only is a file attribute which only allows a user to view a file, restricting any writing to the file. 
// Setting a file to “read-only” will still allow that file to be opened and read; 
// however, changes such as deletions, overwrites, edits or name changes cannot be made.


// Creating a List
// The List<T> is a generic collection, so you need to specify a type parameter for the type of data it can store. 
//The following example shows how to create list and add elements.

// Example: Adding elements in List
// List<int> primeNumbers = new List<int>();
// primeNumbers.Add(1); // adding elements using add() method
// primeNumbers.Add(3);
// primeNumbers.Add(5);
// primeNumbers.Add(7);


// Why do we need IEnumerable in C#?
// IEnumerable in C# is an interface that defines one method, GetEnumerator which returns an IEnumerator interface. 
// This allows readonly access to a collection then a collection that implements IEnumerable can be used with a for-each statement.