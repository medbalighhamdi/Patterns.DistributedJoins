using System;

namespace Patterns.DistributedJoins.Domain.ProductAggregate;

public class Product
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public DateTime InventoryCreatedAt { get; init; }
    public Guid PostedByUserId { get; init; }
    public Guid RatingId { get; private set; }

    public Product(Guid id, string name, DateTime inventoryCreatedAt, Guid postedByUserId)
    {
        Id = id;
        Name = name;
        InventoryCreatedAt = inventoryCreatedAt;
        PostedByUserId = postedByUserId;
    }
}
