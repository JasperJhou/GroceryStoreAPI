# ASP.NET Core API Demo: GroceryStoreAPI
(.NET Core 3.1)


## Requirements
 - API listing all customers
 - API retrieving a customer
 - API adding a customer
 - API updating a customer
 - Unit tests
  
## Design
  * Dependency Injection
  * Unit Tests with xUnit
  
## Assumptions
  * We don't have real database so I created these dummy data [
    {
        "id": 1,
        "name": "Bob"
    },
    {
        "id": 2,
        "name": "Mary"
    },
    {
        "id": 3,
        "name": "Joe"
    }
] in CustomerService, which I'm going to inject to the controller at the time of testing.
  * The AddCustomer function will automatically increment the last id by 1 as a new customer's id.
  
  
  
  
