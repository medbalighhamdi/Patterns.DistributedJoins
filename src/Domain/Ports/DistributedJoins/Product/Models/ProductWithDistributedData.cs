using DistributedJoins.Domain.Ports.Adapters.Models;
using DomainProduct = DistributedJoins.Domain.ProductAggregate.Product;

namespace DistributedJoins.Domain.Ports.DistributedJoins.Product.Models;

public record ProductWithDistributedData(DomainProduct Product, User PostedByUser, Rating Rating);