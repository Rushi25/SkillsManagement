# Skills Management API

A .NET 8.0 Web API project for managing employee skills across different customers.

## Overview

The Skills Management API provides a comprehensive solution for tracking and managing employee skills within organizations. It allows companies to maintain records of their employees' skills and proficiency levels, making it easier to identify talent and manage workforce capabilities.

## Features

- Customer Management
- Employee Management
- Skills Tracking
- Skill Rating System
- Reporting Capabilities

## Technology Stack

- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI

## Project Structure

```
SkillsManagement/
├── Controllers/
│   ├── CustomersController.cs
│   ├── EmployeesController.cs
│   ├── EmployeeSkillsController.cs
│   └── ReportsController.cs
├── DTO/
│   ├── EmployeeSkillDto.cs
│   └── SkillReport.cs
├── Entities/
│   ├── Customer.cs
│   ├── Employee.cs
│   └── EmployeeSkill.cs
└── Migrations/
```

## Data Models

### Customer
- Base entity for organization management

### Employee
- Belongs to a Customer
- Contains basic employee information

### EmployeeSkill
- Links employees with their skills
- Includes skill ratings
- Associated with specific customers

## Getting Started

1. Clone the repository
2. Update the connection string in `appsettings.json`
3. Run Entity Framework migrations:
   ```powershell
   dotnet ef database update
   ```
4. Run the application:
   ```powershell
   dotnet run
   ```
5. Access Swagger UI at `https://localhost:[port]/swagger`

## API Documentation

The API is documented using Swagger/OpenAPI. When running in development mode, you can access the interactive documentation at the `/swagger` endpoint.

## Database Migrations

The project uses Entity Framework Core migrations for database management. All migrations are included in the `Migrations` folder.