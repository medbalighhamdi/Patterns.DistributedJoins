# Distributed Joins

Distributed join is a pattern for HTTP-based microservices.
They enable streamlining remote service consumption on a single interface basis, with optimal performance following HTTP clients' usage best practices.

# Pattern and sub-patterns introductions

Distributed joins englobe an ensemble of collaborating sub-patterns, leading to a better usage of HTTP communications.

## Context

Let's imagine we have boxes that need to be transported from a warehouse (point A) to our store (point B). 
We could make a round trip for each box, but this would be time-consuming, costly, and inefficient.
The most logical solution is to load the truck to maximum capacity before leaving, in order to limit the number of trips.
This is exactly the idea behind the Distributed Joins pattern: rather than sending an HTTP request per product to retrieve the associated customer details, we group all the requests into a single call, which will return the information for all the necessary customers in one go. Then all that remains is to “unload” and associate each customer detail with its product—a bit like distributing the boxes to the right shelf once you arrive.

## Distributed Joins patterns

### Joiner pattern

Joiner classes have JoinWith methods.
JoinWith method: 
   - Fetches entities from the local service repository by the provided ID list in the method parameter.
   - Returns a mapping of remote entities by local entity ID.
     
### Join Controller pattern

JoinController classes have JoinProductWithDistributedData method.
JoinProductWithDistributedData method:
  - Conditions join calls based on the Join Controls values provided in the method parameter.
  - Aggregates join results into a unified product X distributed data-transfer object.

### Join Controls pattern

JoinControl records alter JoinControllers classes' behaviors based on join control boolean values.
Consumers can benefit from a fluent, builder-pattern-based join control creation syntax using custom build methods defined in the same record.

# Class Diagram

```mermaid
%%{ init: { 'layout': 'elk' } }%%
classDiagram
    XXXJoinController *-- XXXYYYJoiner
    XXXJoinController *-- XXXZZZJoiner
    XXXJoinController *-- XXXTTTJoiner
    XXXJoinController <-- XXXConsumer: Calls with join controls
    XXXConsumer -->  JoinControls: Builds
    class XXXYYYJoiner{
      +JoinWithYYY(IEnumerable~XXX~) IDictionary~int, YYY~
    }
    class XXXZZZJoiner{
      +JoinWithZZZ(IEnumerable~XXX~) IDictionary~int, ZZZ~
    }
    class XXXTTTJoiner{
      +JoinWithZZZ(IEnumerable~XXX~, JoinControls) IDictionary~int, TTT~
    }
    class XXXJoinController{
      +JoinWithDistributedData(IEnumerable~XXX~) IEnumerable~XXXWithDistributedData~
    }
     class XXXConsumer{
      +ConsumeXXX()
    }
    class JoinControls{
      -JoinControls()
      +Build() void
      +InnerJoinXXX() JoinControls
      +InnerJoinZZZ() JoinControls
      +InnerJoinYYY() JoinControls
      +
    }
```

# Use cases
The Distributed Join pattern is applied in a context of HTTP-based distributed architectures in case you need:
  - Build performant and solid Infrastructure layer logic for joining local and remote service entities with tackling the most common pitfalls with HTTP-based communications.
  - Abstracting remote service aggregation logic into a single class for multiple consumer usage.
  - A declarative DDD-oriented approach that demegates service aggregation logic into a class holding a central responsibility.
  - A rich domain layer with only service-related logic.
  - An [API Composition pattern](https://microservices.io/patterns/data/api-composition.html) with performant and centralized remote HTTP services aggregation. 
  
# Repository usage

## Prerequisites

The solution is currently built using .NET 9.
.NET SDK is mandatory for building and running the solution.

## Build

The solution is built using the sln file located under the root folder.

## Run

Run the API project located under the src/API folder using the dotnet run command.

# Enhancements

- Managing not found user / rating references with null tolerant mapping with remote services.
- Exception handling and possibility to configure exception settings from calling consumer code, like done for join controls.
