using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{
    //for extension needs to use static class
    public static class Extensions
    {
        //this Item item means operate on current item
        //by calling this means the current item can have a method called AsDto, that returns its identity or version.
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }

}