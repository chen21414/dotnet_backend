using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    //url: GET/ items

    [ApiController] //mark this class API controller; make life easier
    [Route("[items]")]//whatever name of the controller is, that's going to be the route
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        //constructor
        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet] //when performs GET/ items, below is the method reacting to it
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            //was: var items = repository.GetItems();
            //var items = repository.GetItems().Select(item => item.AsDto());
            var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());
            return items;


            //this used to be below, we used extensions instead
            // var items = repository.GetItems().Select(item => new ItemDto {
            //     Id = item.Id,
            //     Name = item.Name,
            //     Price = item.Price,
            //     CreatedDate = item.CreatedDate
            // });
        }
        //we created this GetItems() from Repositories

        //get one specific item
        //GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id) //actionResult allows us to return more than one type (for notFound)
        {
            //var item = repository.GetItemAsync(id);
            var item = await repository.GetItemAsync(id);

            //if can't find the item
            if (item is null)
            {
                return NotFound();//404
            }

            return item.AsDto();
        }

        //post route
        //ActionResult, because we can return more than one thing
        //create an item and return that item got created
        //POST / items
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            //repository.CreateItemAsync(item);
            await repository.CreateItemAsync(item);

            //also return a header where you can get the information about that item
            //CreatedAtAction is whats the action that reflects the route to get information about the item: GetItem
            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
            //above is returning the item's id
        }

        //PUT /items/{id}
        [HttpPut("{id")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }


            //taking an existing item here, and create a copy of it
            //the following properties modified for new values
            //takeing a copy, because Item was created with immutable
            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            //repository.UpdateItemAsync(updatedItem);
            await repository.UpdateItemAsync(updatedItem);

            return NoContent(); //nothing to report
        }

        //DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            //repository.DeleteItemAsync(id);
            await repository.DeleteItemAsync(id);

            return NoContent();
        }
    }
}

// with statement
// The 'with' statement is not meant to improve readability, although whether it does or doesn't is arguable. 
// It is meant to make coding (typing) easier. Having a long dereference string in front of variables is simply an unnecessary nuisance

// What is ActionResult C#?
// An action result is what a controller action returns in response to a browser request. 