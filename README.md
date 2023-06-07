Case: Truck Registration
=====================
As a user, I need a truck register, where I can:
- View registered trucks;
- The minimum truck properties must be:
     - Model (You can only accept FH and FM)
     - Year of Manufacture (Year must be current)
     - Model Year (Can be current or subsequent year)
- Update a truck's information;
- Delete a truck;
- Insert a new truck.

There may be several models of trucks.
-   The models allowed will be only (FH and FM)


## Technologies implemented:

- ASP.NET Core 3.1
 - ASP.NET WebApi Core 3.1
- Entity Framework Core 5.0.17 With Migrations
- .NET Core Native DI
- AutoMapper
- FluentValidator
- Swagger UI
- Xunit Tests with FluentAssertions

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Validations
- Repository
- Unit Tests
- Integration Tests

## How to use:
- You will need the latest Visual Studio 2022 and the latest .NET Core SDK.
- ***Please check if you have installed the same runtime version (SDK) described in global.json***
- The latest SDK and tools can be downloaded from https://dot.net/core.

Also you can run the Project in Visual Studio Code (Windows, Linux or MacOS).

To know more about how to setup your enviroment visit the [Microsoft .NET Download Guide](https://www.microsoft.com/net/download)

##  How to use (Database):
The Project can be used with **In Memory Database**:
- It's necessary to adjust the **appsettings** file given the value **true** for the InMemoryDatabase field.

The Project can be used with **SQL Server Database**:
- It's necessary to adjust the **appsettings**:
    - Update **InMemoryDatabase** field to **false**.
    - Update **DefaultConnection** field to local configuration database.

## Presentations:
- TruckRegistration - Build & Tests (https://youtu.be/tqgACF11Frc).
- TruckRegistration - Api Tests (https://youtu.be/wyGQhu_nxDs).

## References:
- The Equinox Project by [Eduardo Pires](https://github.com/EduardoPires/EquinoxProject).
- Começando com .NET Core, com Arquitetura em Camadas by [Alex Alves](https://alexalvess.medium.com/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686#:~:text=Antes%20de%20come%C3%A7ar%2C%20DDD%20n%C3%A3o,%C3%A9%20independente%20da%20tecnologia%20utilizada.).
- Entity Framework Core by [Microsoft](https://docs.microsoft.com/pt-br/ef/core/.).
- Repository Pattern in ASP.NET Core – Ultimate Guide by [Mukesh Murugan](https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/#:~:text=A%20Repository%20pattern%20is%20a,to%20store%20or%20retreive%20data.).
- Entity Framework Core by [Enity Framework Tutorial](https://www.entityframeworktutorial.net/efcore/entity-framework-core-migration.aspx).