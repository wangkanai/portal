# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Portal template implementing Vertical Slice Architecture (VSA) with .NET 10, Blazor, Microservices, and .NET Aspire for cloud-native orchestration. The architecture is feature-based rather than layered, organizing code by business capability instead of technical concern.

## Build Commands

### .NET CLI Commands
```bash
# Build the solution
dotnet build Portal.slnx

# Run the Aspire AppHost (orchestrates all services)
dotnet run --project Aspire/src/AppHost/Portal.Aspire.AppHost.csproj

# Clean build artifacts
dotnet clean Portal.slnx

# Restore packages (uses Central Package Management)
dotnet restore Portal.slnx
```

### Testing
No tests currently exist in the project structure, but when added they should follow these patterns:
```bash
# Run all tests
dotnet test

# Run tests in specific project
dotnet test path/to/test.csproj

# Run single test with filter
dotnet test --filter "FullyQualifiedName~TestName"
```

## Architecture

### .NET Aspire Cloud-Native Orchestration
The solution uses .NET Aspire for service orchestration, discovery, and observability:

- **AppHost** (`Aspire/src/AppHost/`): Orchestration entry point that configures and launches all services
- **ServiceDefaults** (`Aspire/src/ServiceDefaults/`): Shared Aspire configuration (OpenTelemetry, health checks, service discovery, resilience patterns)

All microservices should reference ServiceDefaults and call `builder.AddServiceDefaults()` to enable:
- Service discovery with resilience handlers
- OpenTelemetry (metrics, tracing, logging)
- Health check endpoints (`/health`, `/alive`)
- HTTP client defaults with standard resilience

### Project Structure (Vertical Slice Architecture)

```
portal/
├── Aspire/                    # .NET Aspire orchestration
│   ├── src/
│   │   ├── AppHost/          # Service orchestration & composition
│   │   └── ServiceDefaults/  # Shared Aspire services configuration
│   └── tests/                # Aspire-related tests
├── Backend/                   # Backend services (currently empty)
│   └── [Features]/           # Each feature is self-contained slice
├── Frontend/                  # Frontend applications (currently empty)
│   └── [Features]/           # Feature-based Blazor components
└── .solution/                # Solution-level configuration
```

### Vertical Slice Architecture Principles

**Feature Organization**: Each feature folder contains all layers needed for that capability:
```
Features/
└── UserManagement/
    ├── GetUser/
    │   ├── GetUserEndpoint.cs      # API endpoint
    │   ├── GetUserHandler.cs       # Business logic
    │   ├── GetUserQuery.cs         # Request model
    │   └── GetUserValidator.cs     # Validation
    └── CreateUser/
        ├── CreateUserEndpoint.cs
        ├── CreateUserHandler.cs
        ├── CreateUserCommand.cs
        └── CreateUserValidator.cs
```

**Anti-pattern**: Do NOT create layered folders like `Controllers/`, `Services/`, `Repositories/`. Group by feature instead.

## Code Standards

### .NET 10 Conventions
- **Target Framework**: `net10.0` (configured in Directory.Build.props)
- **Implicit Usings**: Enabled globally
- **Nullable Reference Types**: Enabled globally
- **File-Scoped Namespaces**: Required (error level)

### Coding Style (.editorconfig enforced)
- **Indentation**: 3 spaces (tabs width: 3)
- **Line Length**: 200 characters max
- **Braces**: Next line for control blocks (Allman style)
- **Expression Bodies**: Preferred for methods, properties, constructors
- **var Usage**: Required for built-in types and when type is apparent
- **Naming**:
  - Interfaces: `IPascalCase`
  - Private fields: `_camelCase` (underscore prefix)
  - Private constants: `PascalCase`
  - Type parameters: `TPascalCase`

### Central Package Management
All NuGet package versions are managed in `Directory.Packages.props`. When adding packages:
1. Add `<PackageReference Include="PackageName" />` to .csproj (no Version attribute)
2. Add `<PackageVersion Include="PackageName" Version="x.y.z" />` to Directory.Packages.props

Current managed packages:
- Microsoft.Extensions.Http.Resilience 10.0.0
- Microsoft.Extensions.ServiceDiscovery 10.0.0
- OpenTelemetry stack 1.14.0

### Copyright Header
All C#, C++, and header files must include:
```csharp
// Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.
```

## Development Workflow

### Adding New Services (Backend/Frontend)
1. Create project in appropriate folder (Backend/ or Frontend/)
2. Reference `Portal.Aspire.ServiceDefaults.csproj`
3. Call `builder.AddServiceDefaults()` in Program.cs
4. Register service in `AppHost.cs` for orchestration
5. Follow VSA principles: organize by feature, not layer

### .NET Aspire Integration Pattern
```csharp
// In service Program.cs
var builder = WebApplication.CreateBuilder(args);

// Add Aspire service defaults (telemetry, discovery, resilience)
builder.AddServiceDefaults();

// Your service configuration here

var app = builder.Build();

// Map Aspire health/alive endpoints
app.MapDefaultEndpoints();

app.Run();
```

### Solution File Format
Using `.slnx` (XML-based solution format) instead of traditional `.sln`. Compatible with Visual Studio 2022+ and JetBrains Rider 2024+.
