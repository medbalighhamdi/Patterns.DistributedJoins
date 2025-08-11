# Distributed Joins

Distributed join is a pattern for HTTP-based microservices.
They allow streamlining remote service consumption on a single interface basis with optimum performance in accordance to HTTP clients usage best practises.

# Patterns and sub-patterns

Distributed joins englobes an ensemble of collaborating sub-patterns.

## Joiner pattern

Joiner classes have JoinWith methods.
JoinWith method: 
   - Fetches entities from local service repository by the provided id list in method parameter.
   - Returns a mapping of remote entities by local entity id.
     
## Join Controller pattern

JoinController classes have JoinProductWithDistributedData method.
JoinProductWithDistributedData method:
  - Conditions join calls based on Join Controls values provided in parameter.

## Join Controls pattern

JoinControl records conditions JoinController class behavior.
They hold boolean properties that are built by consumers.
Consumers can benefit from a fluent, builder-pattern-based join controls creation syntax using custom build methods that are defined in the same record.

# Class Diagram

```mermaid
%%{ init: { 'layout': 'elk' } }%%
classDiagram
    XXXJoinController *-- XXXYYYJoiner
    XXXJoinController *-- XXXZZZJoiner
    XXXJoinController *-- XXXTTTJoiner
    XXXJoinController <-- XXXConsumer  : Calls with join controls
    XXXConsumer -->  JoinControls : Builds
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
      +Initiate() void
      +InnerJoinXXX() JoinControls
      +InnerJoinZZZ() JoinControls
      +InnerJoinYYY() JoinControls
      +
    }
```

# Use cases

Distributed Join pattern is applied in a context of HTTP-based distributed architectures in case we need:
  - Performant join logic between local and remote service entities with tackling the most common pitfalls with HTTP-based communications.
  - Abstracting remote service aggregation logic into a single class for multiple consumer usage.
  - A declarative DDD oriented approach that deports service fetching logic into a class holding a central responsability. 
  - To support DDD with centralizing service distribution logic in Infrastructure layer.
