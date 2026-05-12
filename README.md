# MegaTec 

REST API built with ASP.NET Core for contact management, including SQL Server persistence, image upload, advanced search capabilities, and PDF export functionality.

---

## System Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (`net10.0`)
- SQL Server or LocalDB
- Database connection configured in `appsettings.json` under `ConnectionStrings:DefaultConnection`

---

## Quick Start

```bash
dotnet restore
dotnet ef database update
dotnet run
```

In Development mode, Swagger and Swagger UI are enabled according to the configuration in `Program.cs`.

---

# Project Overview

This project was developed as part of the MegaTec Full Stack assignment using ASP.NET Core and Entity Framework Core.

The API provides a complete contact management solution with:
- SQL Server persistence
- Image upload support
- Advanced search functionality
- Reverse keyboard layout handling
- PDF export generation
- Layered architecture following clean separation of concerns

The project emphasizes maintainability, scalability, and production-oriented development practices.

---

# Architecture Overview

| Layer | Responsibility |
|------|----------------|
| **Controllers** | `PeopleController` — REST API endpoints under `api/people` |
| **Services** | `PersonService` — business logic, file management, search logic, and PDF generation |
| **Data** | `ApplicationDbContext` — EF Core database context |
| **Models** | `Person` entity model |
| **DTOs** | `PersonCreateDto` used for multipart/form-data requests |

The application automatically applies pending EF Core migrations on startup using `Database.Migrate()` to ensure schema synchronization.

---
# Transition from Part A to Part B

Part B was implemented as an extension of the existing Part A codebase without rebuilding the project from scratch, while maintaining backward compatibility and preserving the original API structure.

The transition required coordinated updates across multiple application layers, including:
- Entity models
- DTOs
- EF Core migrations
- Service logic
- API endpoints
- Database schema

The original `FullName` field was refactored into separate `FirstName` and `LastName` fields throughout the system, including database migration support for existing data.

In addition, the project was expanded with:
- `IsActive` status management
- Advanced partial-name search
- Reverse keyboard layout search support (Hebrew ↔ English)
- Improved search maintainability using centralized keyboard conversion logic

All new functionality was integrated into the existing architecture while preserving the original functionality from Part A.
During development, I used Cursor
 to assist with:

EF Core Version Alignment
Ensuring compatibility between:

Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
dotnet-ef

Cursor also helped quickly identify schema/model mismatches after structural changes such as replacing FullName with FirstName and LastName.

Keyboard Layout Conversion Logic
Assisting in building the centralized KeyboardLayoutConverter, including:
Hebrew ↔ English character mapping
Bidirectional conversion support
Integration into SearchByNameAsync without affecting existing API behavior

Using Cursor significantly reduced time spent searching documentation and examples while helping maintain clean, layered architecture changes across:

Models
DTOs
Services
EF Core migrations
External Dependencies & Licensing
QuestPDF
 — Community License (configured in Program.cs)
Additional dependencies are listed in MegaTec_Task.csproj# MegaTec 

REST API built with ASP.NET Core for contact management, including SQL Server persistence, image upload, advanced search capabilities, and PDF export functionality.

---

## System Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (`net10.0`)
- SQL Server or LocalDB
- Database connection configured in `appsettings.json` under `ConnectionStrings:DefaultConnection`

---

## Quick Start

```bash
dotnet restore
dotnet ef database update
dotnet run
```

In Development mode, Swagger and Swagger UI are enabled according to the configuration in `Program.cs`.

---

# Project Overview

This project was developed as part of the MegaTec Full Stack assignment using ASP.NET Core and Entity Framework Core.

The API provides a complete contact management solution with:
- SQL Server persistence
- Image upload support
- Advanced search functionality
- Reverse keyboard layout handling
- PDF export generation
- Layered architecture following clean separation of concerns

The project emphasizes maintainability, scalability, and production-oriented development practices.

---

# Architecture Overview

| Layer | Responsibility |
|------|----------------|
| **Controllers** | `PeopleController` — REST API endpoints under `api/people` |
| **Services** | `PersonService` — business logic, file management, search logic, and PDF generation |
| **Data** | `ApplicationDbContext` — EF Core database context |
| **Models** | `Person` entity model |
| **DTOs** | `PersonCreateDto` used for multipart/form-data requests |

The application automatically applies pending EF Core migrations on startup using `Database.Migrate()` to ensure schema synchronization.

---
# Transition from Part A to Part B

Part B was implemented as an extension of the existing Part A codebase without rebuilding the project from scratch, while maintaining backward compatibility and preserving the original API structure.

The transition required coordinated updates across multiple application layers, including:
- Entity models
- DTOs
- EF Core migrations
- Service logic
- API endpoints
- Database schema

The original `FullName` field was refactored into separate `FirstName` and `LastName` fields throughout the system, including database migration support for existing data.

In addition, the project was expanded with:
- `IsActive` status management
- Advanced partial-name search
- Reverse keyboard layout search support (Hebrew ↔ English)
- Improved search maintainability using centralized keyboard conversion logic

All new functionality was integrated into the existing architecture while preserving the original functionality from Part A.
During development, I used Cursor
 to assist with:

EF Core Version Alignment
Ensuring compatibility between:

Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
dotnet-ef

Cursor also helped quickly identify schema/model mismatches after structural changes such as replacing FullName with FirstName and LastName.

Keyboard Layout Conversion Logic
Assisting in building the centralized KeyboardLayoutConverter, including:
Hebrew ↔ English character mapping
Bidirectional conversion support
Integration into SearchByNameAsync without affecting existing API behavior

Using Cursor significantly reduced time spent searching documentation and examples while helping maintain clean, layered architecture changes across:

Models
DTOs
Services
EF Core migrations
External Dependencies & Licensing
QuestPDF
 — Community License (configured in Program.cs)
Additional dependencies are listed in MegaTec_Task.csproj
