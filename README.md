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


### Database Creation and Migration
1. Install Entity Framework Core tools (if not already installed):
```bash
dotnet tool install --global dotnet-ef
```

2. Create the database:
```bash
dotnet dotnet ef database update --project src/Ambev.DeveloperEvaluation.ORM --startup-project src/Ambev.DeveloperEvaluation.WebApi
```

### Database Initialization
For initial setup, execute the following script in your PostgreSQL database:

```sql
-- Insert into "Customers"
INSERT INTO "Customers" ("Id", "MainName", "ContractName", "Phone", "Email", "CreatedAt", "UpdatedAt")
VALUES ('11111111-1111-1111-1111-111111111111', 'John Doe', 'John Contract', '(11) 91234-5678', 'john.doe@example.com', '2023-10-01 12:00:00', NULL);

-- Insert into "Products"
INSERT INTO "Products" ("Id", "Title", "Price", "Description", "Category", "RateAverage")
VALUES ('22222222-2222-2222-2222-222222222222', 'Product A', 99.99, 'Description of Product A', 'Category A', 4.5);

-- Insert into "Ratings"
INSERT INTO "Ratings" ("Id", "CustomerId", "ProductId", "Rate")
VALUES ('33333333-3333-3333-3333-333333333333', '66666666-6666-6666-6666-666666666666', '22222222-2222-2222-2222-222222222222', 5);

-- Insert into "SaleItems"
INSERT INTO "SaleItems" ("Id", "ProductId", "Quantity", "UnitPrice", "Discount")
VALUES ('44444444-4444-4444-4444-444444444444', '22222222-2222-2222-2222-222222222222', 2, 49.99, 5.00);

-- Insert into "Sales"
INSERT INTO "Sales" ("Id", "SalesNumber", "SalesDate", "TotalOfSale", "IsCanceled", "CustomerId", "SubsidiaryId")
VALUES ('55555555-5555-5555-5555-555555555555', 123456, '2023-10-01 12:00:00', 199.98, FALSE, '11111111-1111-1111-1111-111111111111', '66666666-6666-6666-6666-666666666666');

-- Insert into "Subsidiaries"
INSERT INTO "Subsidiaries" ("Id", "Name", "CompanyIdentifierCode", "Address", "Phone", "CreatedAt", "UpdatedAt")
VALUES ('66666666-6666-6666-6666-666666666666', 'Subsidiary A', '123456789', '123 Main St', '(11) 91234-5678', '2023-10-01 12:00:00', NULL);
```

Note: In a production environment, this initialization would be handled through Docker containers and automated database seeding during the initial setup.


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

### Running Integration Tests
```bash
cd tests/Ambev.DeveloperEvaluation.Integration
dotnet test
```

## Project Structure

```
src/
├── Ambev.DeveloperEvaluation.WebApi/        # API endpoints and controllers
├── Ambev.DeveloperEvaluation.Application/   # Application logic and handlers
├── Ambev.DeveloperEvaluation.Domain/        # Entities and business rules
├── Ambev.DeveloperEvaluation.Infrastructure/# Data access and external services
└── Ambev.DeveloperEvaluation.IoC/           # Dependency injection configuration

tests/
├── Ambev.DeveloperEvaluation.Unit/          # Unit tests
├── Ambev.DeveloperEvaluation.Integration/   # Integration tests
└── Ambev.DeveloperEvaluation.Functional/    # Functional tests
```

### Main Features
- `SalesController`: Sales management endpoints
- `GetSale`: Sales query functionality
- `CreateSale`: Sales creation functionality
- `UpdateSale`: Sales update functionality

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.