using System;

namespace Catalog.Dtos
{
    public record ItemDto
    {
        public Guid Id { get; init; }//using init instead of private set because we want immutable property

        public string Name { get; init; }

        public decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}