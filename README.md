# Employee Management System

## Overview

Employee Management System is an ASP.NET Core Web API application
used to manage employee and department information.

The application provides REST APIs for employee management,
authentication, and database operations.

## Technologies Used

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- LINQ
- REST API
- Dependency Injection
- Git & GitHub

## Features

- Employee Management
- Department Management
- Employee CRUD Operations
- User Authentication
- Database Integration
- Entity Framework Core Migrations
- RESTful APIs
- Exception Handling
- Employee Search

## Project Structure

```text
EmployeeManagementSystem
│
├── Controllers
│   ├── AuthController.cs
│   ├── EmployeeController.cs
│   └── HomeController.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Migrations
│
├── Models
│   ├── Employee.cs
│   └── Department.cs
│
├── EmployeeManagementSystem.csproj
└── Program.cs