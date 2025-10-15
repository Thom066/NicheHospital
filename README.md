# NicheHospital - Hospital Management System

## Description
NicheHospital is a hospital management system developed with ASP.NET Core 8.0, designed to facilitate the administration of medical appointments, doctor information, and patient data. The system provides an intuitive web interface for efficient hospital resource management.

## Technologies Used
- ASP.NET Core 8.0
- Entity Framework Core 8.0.4
- PostgreSQL (Npgsql 8.0.4)
- Razor Views
- Bootstrap (Frontend)
- jQuery

## Main Features
- Doctor Management (Complete CRUD)
- Patient Management (Complete CRUD)
- Medical Appointment System
- Server-side Data Validation
- Responsive Interface
- Error Logging System

## System Requirements
- .NET 8.0 SDK
- PostgreSQL
- Modern Web Browser

## Project Setup
1. Clone the repository
2. Configure the connection string in `appsettings.json`
3. Run migrations:
```bash
dotnet ef database update
```
4. Run the project:
```bash
dotnet run
```

## Project Structure
```
├── Controllers/          # Application controllers
├── Models/              # Data models
├── Views/               # Razor views
├── Data/                # Database context
├── wwwroot/            # Static files
└── Migrations/         # Database migrations
```

## License
This project is under the MIT License.
