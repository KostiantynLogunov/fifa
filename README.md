### Clean Architecture is here :-)
#### Structure:
+ Core
    - FIFA.Application - there is all logics of getting, creation, modifying of enteties and validation of this requests (scenario of using)
    - FIFA.Domain - there are descriptions of entities
+ Infrastructure
    - FIFA.Persistence - interction with DataBase
+ Presentetion
    - FIFA.WebApi 
+ Test
