# ASP.NET REST API for storing company data from Brønnøysundregistrene

## Installation Guide
### Requirements
- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [SQL Server 2022 Express](https://www.microsoft.com/en-us/download/details.aspx?id=104781)

### Installation
- Clone and navigate to the project
- Run the following commands to set up database access:
- `dotnet tool install --global dotnet-ef`
- `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
- `dotnet add package Microsoft.EntityFrameworkCore.Design`
- `dotnet ef migrations add InitialCreate`
- `dotnet ef database update`
- Run project using `dotnet run --launch-profile https`
- Api can be accesed at https://localhost:7128
- OpenApi Scalar interface available at https://localhost:7128/scalar/v1

## Project Structure

```
└── 📁BrregApi
    └── 📁Context
        └── CustomerDbContext.cs
    └── 📁Controllers
        └── CustomerController.cs
        └── WeatherForecastController.cs
    └── 📁Models
        └── Address.cs
        └── Company.cs
        └── Customer.cs
        └── OrganizationType.cs
    └── 📁Properties
        └── launchSettings.json
    └── appsettings.Development.json
    └── appsettings.json
    └── BrregApi.csproj
    └── BrregApi.csproj.user
    └── BrregApi.http
    └── BrregApi.sln
    └── Program.cs
    └── WeatherForecast.cs
```
