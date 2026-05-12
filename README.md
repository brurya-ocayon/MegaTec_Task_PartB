MegaTec - Contact Management System
A production-ready REST API built with ASP.NET Core (.NET 10) for advanced contact management. This project features SQL Server persistence, secure image uploads, PDF report generation, and a sophisticated search engine with keyboard layout awareness.

🚀 Quick Start
Prerequisites: Ensure .NET 10 SDK and SQL Server/LocalDB are installed.

Configuration: Update the DefaultConnection in appsettings.json.

Database Setup:

Bash
dotnet restore
dotnet ef database update
Run:

Bash
dotnet run
Swagger UI is available in Development mode at /swagger.

🛠 Project Architecture
The system follows a Clean Layered Architecture to ensure separation of concerns and maintainability:

Layer	Responsibility
Controllers	PeopleController — RESTful endpoints managing the api/people route.
Services	PersonService — Core business logic, file I/O, search algorithms, and PDF orchestration.
Data	ApplicationDbContext — EF Core context with automated migration application on startup.
Models/DTOs	Strongly typed entities and Data Transfer Objects for optimized request/response handling.
🔄 The Part A to Part B Evolution
A key requirement of this task was the strategic refactoring of existing code. The transition from a basic CRUD API (Part A) to an advanced system (Part B) involved:

Schema Migration: Refactored the FullName field into FirstName and LastName. This included an EF Core Migration strategy that preserved existing data during the split.

Status Management: Integrated an IsActive state with optimized server-side filtering.

Advanced Search Engine: Implemented a non-breaking extension to the search logic, allowing partial name matches.

🧠 Special Features & Logic
1. Reverse Keyboard Layout Search (Hebrew ↔ English)
To solve the common user error of typing in the wrong language layout (e.g., "atv" instead of "אבי"), I implemented a centralized KeyboardLayoutConverter.

Bidirectional Mapping: Supports both Hebrew-to-English and English-to-Hebrew.

Seamless Integration: The search service automatically detects and converts queries without requiring additional input from the user.

2. PDF Generation (QuestPDF)
Utilizes the QuestPDF library under the Community License to generate professional, document-standard PDF reports for personnel records.

3. Modern Development Workflow (AI-Assisted)
During development, Cursor was utilized to accelerate:

Refactoring Safety: Ensuring model/DTO synchronization across layers after the FullName split.

Version Alignment: Maintaining strict compatibility between .NET 10 and the latest EF Core preview packages.

Boilerplate Efficiency: Faster implementation of mapping logic and unit-test structures.

📋 Features List
[x] Full CRUD Operations (Create, Read, Update, Delete)

[x] Relational Persistence (SQL Server)

[x] Multipart Image Upload with validation

[x] PDF Export via QuestPDF

[x] Smart Search with Keyboard Layout Awareness

[x] Automated Migrations on startup

External Dependencies
QuestPDF: For report generation.

EF Core & SQL Server: For data persistence.

