using System;

namespace Catalog.Entities
{
    public record Item
    {
        public Guid Id { get; init; }//using init instead of private set because we want immutable property

        public string Name { get; init; }

        public decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}



// What is record in C#?
// Beginning with C# 9, you use the record keyword to define a reference type that provides built-in functionality for encapsulating data. 
// C# 10 allows the record class syntax as a synonym to clarify a reference type, 
// and record struct to define a value type with similar functionality.

// NET using C# Guid class. GUID stands for Global Unique Identifier. 
// A GUID is a 128-bit integer (16 bytes) that you can use across all computers and networks wherever a unique identifier is required.