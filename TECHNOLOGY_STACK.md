# Technology Stack

This document outlines the complete technology stack used in the Portal Template project.

## .NET Platform

### Core Framework
- **.NET 10** with **C# 14**
  - Target Framework: `net10.0`
  - Implicit usings enabled
  - Nullable reference types enabled
  - File-scoped namespaces required

### ASP.NET Core 10
- Web API development
- Blazor Server
- Blazor WebAssembly
- Middleware pipeline
- Dependency injection

### Blazor
- **Blazor Server**: Server-side rendering with SignalR
- **Blazor WebAssembly**: Client-side execution in browser
- Interactive render modes
- Component-based architecture

## Data Access & Storage

### Entity Framework Core 10
- **Code-First** approach
- Database providers:
  - SQL Server (`Microsoft.EntityFrameworkCore.SqlServer`)
  - PostgreSQL (`Npgsql.EntityFrameworkCore.PostgreSQL`)
  - SQLite (`Microsoft.EntityFrameworkCore.Sqlite`)
- Migrations support
- LINQ query support

### Databases
- **SQL Server**: Primary production database
- **PostgreSQL**: Alternative database option (configured in Aspire)
- **SQLite**: Development and testing database

### Caching
- **Redis Cache**: Distributed caching
  - `Microsoft.Extensions.Caching.StackExchangeRedis`
  - `StackExchange.Redis`

## Authentication & Authorization

### ASP.NET Identity
- User management
- Role-based authorization
- Identity stores with Entity Framework Core
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore`

### Authentication Providers
- **Windows Authentication**: `Microsoft.AspNetCore.Authentication.Negotiate`
- **ThaiID Authentication**: To be configured for Thai national ID card authentication

## Cloud-Native & Orchestration

### .NET Aspire 13.0
- Service orchestration
- Service discovery
- Distributed tracing with OpenTelemetry
- Health checks
- Resilience patterns
- Dashboard for monitoring

## Frontend Technologies

### CSS Preprocessing
- **Dart SCSS**: ^1.94
  - Sass compilation
  - Build scripts in package.json
  - Source: `wwwroot/scss`
  - Output: `wwwroot/css`

### JavaScript & TypeScript
- **Node.js**: 20.x (LTS)
- **NPM**: ^11.6.3
- **TypeScript**: ^5.9
  - Target: ES2022
  - Module: ESNext
  - Strict mode enabled
  - Source maps enabled

## Testing Framework

### C# Testing
- **xUnit v3**: 3.2.0
  - Primary test framework
  - xUnit analyzers for best practices
  - Visual Studio test runner integration
  - `xunit.v3`, `xunit.analyzers`, `xunit.runner.visualstudio`

### Blazor Testing
- **bUnit**: 1.35.3
  - Blazor component testing
  - `bUnit.web` for web components
  - Integration with xUnit

### Assertions
- **Fluent Assertions**: 7.0.0
  - Readable test assertions
  - Extensive assertion methods
  - Compatible with xUnit v3

### Integration Testing
- **Microsoft.AspNetCore.TestHost**: Test server hosting
- **Microsoft Testing Platform**: 18.0.1
  - Modern test execution
  - `Microsoft.NET.Test.Sdk`

### Container Testing
- **Testcontainers**: 4.0.0
  - Docker-based integration testing
  - `Testcontainers.MsSql`: SQL Server containers
  - `Testcontainers.PostgreSql`: PostgreSQL containers
  - `Testcontainers.Redis`: Redis containers

## CI/CD

### GitHub Actions
- Automated build pipeline
- Test execution
- Security scanning
- Artifact publishing
- Docker image building
- Configuration: `.github/workflows/ci-cd.yml`

### GitLab Community
- Full CI/CD pipeline
- Multi-stage builds
- Integration testing with services
- Manual deployment gates
- Configuration: `.gitlab-ci.yml`

## Development Tools

### Package Management
- **Central Package Management**: All NuGet versions managed in `Directory.Packages.props`
- **NPM**: JavaScript package management
- **NuGet**: .NET package management

### Build System
- **MSBuild**: .NET build system
- **Solution Format**: `.slnx` (XML-based)
- Build properties in `Directory.Build.props`
- Build targets in `Directory.Build.targets`

### Code Quality
- **EditorConfig**: Code style enforcement (`.editorconfig`)
- **Source Link**: Debug symbol source mapping
- **Analyzers**: xUnit analyzers, Roslyn analyzers

## OpenTelemetry (Observability)

- **OpenTelemetry.Exporter.OpenTelemetryProtocol**: 1.14.0
- **OpenTelemetry.Extensions.Hosting**: 1.14.0
- **OpenTelemetry.Instrumentation.AspNetCore**: 1.14.0
- **OpenTelemetry.Instrumentation.Http**: 1.14.0
- **OpenTelemetry.Instrumentation.Runtime**: 1.14.0

## Resilience & Service Discovery

- **Microsoft.Extensions.Http.Resilience**: 10.0.0
  - Retry policies
  - Circuit breakers
  - Timeout policies
  
- **Microsoft.Extensions.ServiceDiscovery**: 10.0.0
  - Service discovery integration
  - Load balancing

## Architecture Pattern

### Vertical Slice Architecture
- Feature-based organization
- Self-contained slices
- Each feature contains all layers
- Minimal cross-feature dependencies

## Version Requirements Summary

| Technology | Version | Status |
|------------|---------|--------|
| .NET | 10.0 | ✅ Configured |
| C# | 14 | ✅ Configured |
| ASP.NET Core | 10.0 | ✅ Configured |
| Blazor Server | 10.0 | ✅ Configured |
| Blazor WebAssembly | 10.0 | ✅ Configured |
| ASP.NET Identity | 10.0 | ✅ Configured |
| Entity Framework Core | 10.0 | ✅ Configured |
| SQL Server (EF Provider) | 10.0 | ✅ Configured |
| PostgreSQL (EF Provider) | 10.0 | ✅ Configured |
| Redis | Latest | ✅ Configured |
| Dart SCSS | ^1.94 | ✅ Configured |
| NPM | ^11.6.3 | ✅ Configured |
| Node.js | 20.x | ✅ Configured |
| TypeScript | ^5.9 | ✅ Configured |
| Aspire | 13.0 | ✅ Configured |
| xUnit v3 | 3.2.0 | ✅ Configured |
| bUnit | 1.35.3 | ✅ Configured |
| Fluent Assertions | 7.0.0 | ✅ Configured |
| Testcontainers | 4.0.0 | ✅ Configured |
| Microsoft Testing Platform | 18.0.1 | ✅ Configured |
| Windows Authentication | 10.0 | ✅ Configured |
| ThaiID Authentication | - | 🔄 To be implemented |
| GitHub Actions | - | ✅ Configured |
| GitLab CI | - | ✅ Configured |

## Notes

### ThaiID Authentication
ThaiID (Thai National ID Card) authentication requires specific integration with Thai government PKI infrastructure. Implementation will require:
- Thai Digital ID middleware
- Certificate validation
- Integration with appropriate Thai government services

### Windows Authentication
Windows Authentication is configured via `Microsoft.AspNetCore.Authentication.Negotiate` package and supports:
- NTLM authentication
- Kerberos authentication
- Integration with Active Directory
- Single Sign-On (SSO) in Windows environments

## Getting Started

### Prerequisites
```bash
# .NET SDK
dotnet --version  # Should be 10.0.x

# Node.js and NPM
node --version    # Should be 20.x
npm --version     # Should be 11.6.3 or higher

# Docker (for Testcontainers)
docker --version
```

### Build
```bash
# Restore dependencies
dotnet restore Portal.slnx

# Install npm dependencies
cd Frontend/Portal/src/Server
npm install

# Build SCSS
npm run build:css

# Build solution
cd ../../../..
dotnet build Portal.slnx
```

### Run Tests
```bash
dotnet test Portal.slnx
```

### Run Application (Aspire)
```bash
dotnet run --project Aspire/src/AppHost/Portal.Aspire.AppHost.csproj
```

## License
Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.
