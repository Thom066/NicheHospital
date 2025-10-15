# NicheHospital - Sistema de Gestión Hospitalaria

## Descripción
NicheHospital es un sistema de gestión hospitalaria desarrollado con ASP.NET Core 8.0, diseñado para facilitar la administración de citas médicas, información de doctores y pacientes. El sistema proporciona una interfaz web intuitiva para la gestión eficiente de los recursos hospitalarios.

## Tecnologías Utilizadas
- ASP.NET Core 8.0
- Entity Framework Core 8.0.4
- PostgreSQL (Npgsql 8.0.4)
- Razor Views
- Bootstrap (Frontend)
- jQuery

## Características Principales
- Gestión de Doctores (CRUD completo)
- Gestión de Pacientes (CRUD completo)
- Sistema de Citas Médicas
- Validación de datos en el servidor
- Interfaz responsiva
- Sistema de registro de errores

## Requisitos del Sistema
- .NET 8.0 SDK
- PostgreSQL
- Navegador web moderno

## Configuración del Proyecto
1. Clonar el repositorio
2. Configurar la cadena de conexión en `appsettings.json`
3. Ejecutar las migraciones:
```bash
dotnet ef database update
```
4. Ejecutar el proyecto:
```bash
dotnet run
```

## Estructura del Proyecto
```
├── Controllers/          # Controladores de la aplicación
├── Models/              # Modelos de datos
├── Views/               # Vistas Razor
├── Data/                # Contexto de base de datos
├── wwwroot/            # Archivos estáticos
└── Migrations/         # Migraciones de base de datos
```

## Licencia
Este proyecto está bajo la licencia MIT.

---

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