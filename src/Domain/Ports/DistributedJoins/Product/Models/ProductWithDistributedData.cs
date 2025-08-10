using Patterns.DistributedJoins.Domain.ProductAggregate;

public record ProductWithDistributedData(Product Product, User PostedByUser, Rating Rating);