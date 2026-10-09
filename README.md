<p align="center">
    <img src="docs/images/origen-logo.png" width="220" alt="ORIGEN Logo">
</p>

<h1 align="center">ORIGEN</h1>

<p align="center">
<b>Enterprise Full Stack Platform built with ASP.NET Core 9 and Angular 20</b>
</p>

<p align="center">
ASP.NET Core 9 • Angular 20 • SQL Server • Entity Framework Core • JWT • Angular Material
</p>

---

ORIGEN is a modern enterprise Full Stack platform developed to demonstrate production-ready software architecture using **ASP.NET Core 9**, **Angular 20**, **Entity Framework Core**, **SQL Server**, and **JWT Authentication**.

The project focuses on clean architecture, modularity, maintainability, secure authentication, role-based authorization, and enterprise software development best practices.

---

# Technology Stack

| Layer | Technologies |
|--------|--------------|
| Backend | .NET 9, ASP.NET Core |
| Frontend | Angular 20, Angular Material |
| Security | JWT Authentication, BCrypt, Role-Based Authorization |
| Persistence | Entity Framework Core |
| Database | SQL Server 2022 |
| API Documentation | OpenAPI / Swagger |
| Build | .NET CLI |

---

# Key Features

- Enterprise Full Stack Architecture
- Modular Monolith
- ASP.NET Core 9
- Angular 20
- Angular Material
- Entity Framework Core
- SQL Server
- JWT Authentication
- Role-Based Access Control (RBAC)
- User Management CRUD
- Automatic `USER` role assignment
- Protected REST API endpoints
- Swagger / OpenAPI with Bearer Authentication
- Auditing with `CreatedAt` and `UpdatedAt`
- Dependency Injection
- SOLID Principles
- Clean Code
- Conventional Commits
- Git Flow

---

# Project Status

| Component | Status |
|-----------|--------|
| Backend | ✅ Stable |
| Authentication | ✅ Completed |
| Authorization (RBAC) | ✅ Completed |
| Angular Integration | ✅ Completed |
| Login Module | ✅ Completed |
| User Management | ✅ Completed |
| Dashboard Structure | 🚧 In Progress |
| Role Management | 📋 Planned |
| Permission Management | 📋 Planned |
| Refresh Token | 📋 Planned |
| Docker Support | 📋 Planned |
| CI/CD | 📋 Planned |

---

# Application

## Login

<p align="center">
    <img src="docs/images/login.png" width="100%" alt="Login">
</p>

Modern authentication interface built with Angular 20 and Angular Material.

---

## Swagger

<p align="center">
    <img src="docs/images/swagger.png" width="100%" alt="Swagger">
</p>

Interactive REST API documentation generated using OpenAPI.

Swagger supports Bearer Authentication, allowing protected endpoints to be tested using JWT access tokens.

---

# Architecture

<p align="center">
    <img src="docs/images/architecture.png" width="100%" alt="Architecture">
</p>

ORIGEN follows a modular architecture where each feature owns its controllers, services, repositories and DTOs, promoting maintainability, scalability and separation of concerns.

The backend is organized by modules, following a structure inspired by enterprise applications and modular monolith architectures.

---

# Current Features

## Backend

- ASP.NET Core 9
- REST API
- Entity Framework Core
- Dependency Injection
- Configuration using Options Pattern
- Global exception handling
- Modular application structure
- Auditable entities

## Authentication & Authorization

- JWT Authentication
- BCrypt password hashing
- Role-Based Access Control (RBAC)
- `ADMIN` and `USER` roles
- Role claims included in JWT
- Protected API endpoints
- HTTP `401 Unauthorized` for unauthenticated requests
- HTTP `403 Forbidden` for unauthorized roles

## User Management

User management is implemented through a REST API with the following operations:

- Get all users
- Get user by ID
- Create user
- Update user
- Delete user

New users are automatically assigned the `USER` role.

Passwords are never returned through API responses.

## Database

- SQL Server 2022
- Entity Framework Core
- Entity Framework Core Migrations
- Relational authorization model
- Roles
- Permissions
- User-role relationships
- Role-permission relationships
- Audit fields

## Frontend

- Angular 20
- Angular Material
- Login Module
- Route Guards
- JWT Interceptor
- Initial Dashboard Structure

---

# API Endpoints

## Authentication

| Method | Endpoint | Description | Authorization |
|--------|----------|-------------|---------------|
| POST | `/api/v1/auth/login` | Authenticate user | Public |

## Users

| Method | Endpoint | Description | Authorization |
|--------|----------|-------------|---------------|
| GET | `/api/v1/users` | Get all users | `ADMIN` |
| GET | `/api/v1/users/{id}` | Get user by ID | Authenticated |
| POST | `/api/v1/users` | Create user | Authenticated |
| PUT | `/api/v1/users/{id}` | Update user | Authenticated |
| DELETE | `/api/v1/users/{id}` | Delete user | Authenticated |

---

# Getting Started

## 1. Clone the repository

```bash
git clone https://github.com/esteban-navarro/origen-dotnet.git

cd origen-dotnet
```

---

## 2. Configure the Backend

Copy:

```text
backend/src/Origen.Api/appsettings.Development.example.json
```

to:

```text
backend/src/Origen.Api/appsettings.Development.json
```

Configure:

- SQL Server connection
- JWT Secret
- JWT Issuer
- JWT Audience

---

## 3. Run the Backend

```bash
cd backend/src/Origen.Api

dotnet restore

dotnet build

dotnet ef database update

dotnet run
```

Backend:

```text
https://localhost:7225
```

---

## 4. Run the Frontend

```bash
cd frontend

npm install

ng serve
```

Frontend:

```text
http://localhost:4200
```

---

# Default Credentials

| Username | Password |
|----------|----------|
| admin | Admin123* |

The default administrator account is created during application startup when bootstrap configuration is enabled.

---

# API Documentation

Swagger UI:

```text
https://localhost:7225/swagger
```

---

# Repository Structure

```text
ORIGEN
│
├── backend
│   └── src
│       └── Origen.Api
│           ├── Controllers
│           ├── Data
│           ├── Extensions
│           └── Modules
│               ├── Auth
│               │   ├── Bootstrap
│               │   ├── Configurations
│               │   ├── Controllers
│               │   ├── DTOs
│               │   ├── Entities
│               │   ├── Repositories
│               │   ├── Security
│               │   └── Services
│               │
│               └── Users
│                   ├── Controllers
│                   ├── DTO
│                   │   ├── Requests
│                   │   └── Responses
│                   └── Services
│
├── frontend
│
├── docs
│   └── images
│
├── README.md
│
└── LICENSE
```

---

# Roadmap

## Completed

- ASP.NET Core Foundation
- Entity Framework Core
- SQL Server Integration
- Database Migrations
- JWT Authentication
- RBAC Authorization
- Role Management foundation
- Permission Management foundation
- Swagger Documentation
- Bearer Authentication in Swagger
- Angular Integration
- Login Module
- User Management CRUD
- Automatic `USER` role assignment
- API auditing

---

## In Progress

- Dashboard Module
- Frontend Navigation
- Frontend User Management

---

## Planned

- Permission-based authorization policies
- Role Management UI
- Permission Management UI
- Refresh Token
- Docker Support
- Docker Compose
- Unit Testing
- Integration Testing
- GitHub Actions
- CI/CD Pipeline

---

# Development Practices

- Modular Monolith
- Clean Architecture principles
- SOLID Principles
- REST API Design
- Dependency Injection
- DTO-based API design
- Conventional Commits
- Git Flow
- Clean Code
- Separation of Concerns

---

# License

This project is licensed under the MIT License.
