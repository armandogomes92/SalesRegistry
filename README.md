# Sales Registry API

## Project Overview
The Sales Registry is a RESTful API developed to manage sales records. The system allows the registration, querying, and updating of sales, with support for multiple items per sale.

### Technologies Used
- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- xUnit
- FluentAssertions
- Swagger/OpenAPI

## Environment Setup

### Prerequisites
- .NET 8.0 SDK or higher
- Visual Studio 2022 or VS Code
- PostgreSQL 13 with appsettings user or configure a user as shown below

### `appsettings.json` Configuration

In the `appsettings.json` file, configure the PostgreSQL connection string:

```json
{
   "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Database=SalesRegistry;Username=your_user;Password=your_password"
   },
   "Logging": {
      "LogLevel": {
         "Default": "Information",
         "Microsoft": "Warning",
         "Microsoft.Hosting.Lifetime": "Information"
      }
   },
   "AllowedHosts": "*"
}
```

Replace `your_user` and `your_password` with your PostgreSQL database credentials.

### Initial Setup
1. Clone the repository
```bash
git clone https://github.com/armandogomes92/SalesRegistry.git
cd SalesRegistry
```

2. Restore NuGet packages
```bash
dotnet restore
```

3. Configure the connection string in `appsettings.json`

## Running the Project

### Build
```bash
dotnet build
```

### Running the API
```bash
cd src/Ambev.DeveloperEvaluation.WebApi
dotnet run
```

The API will be available at `https://localhost:5001`

## Tests

### Running Unit Tests
```bash
cd tests/Ambev.DeveloperEvaluation.Unit
dotnet test
```

### Running Functional Tests
```bash
cd tests/Ambev.DeveloperEvaluation.Functional
dotnet test
```

## Project Structure

```
src/
├── Ambev.DeveloperEvaluation.WebApi/        # API endpoints and controllers
├── Ambev.DeveloperEvaluation.Application/   # Application logic and handlers
├── Ambev.DeveloperEvaluation.Domain/        # Entities and business rules
├── Ambev.DeveloperEvaluation.Infrastructure/# Data access and external services
└── Ambev.DeveloperEvaluation.IoC/          # Dependency injection configuration

tests/
├── Ambev.DeveloperEvaluation.Unit/          # Unit tests
└── Ambev.DeveloperEvaluation.Functional/    # Functional tests
```

### Main Features
- `SalesController`: Sales management endpoints
- `GetSale`: Sales query functionality
- `CreateSale`: Sales creation functionality
- `UpdateSale`: Sales update functionality

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.