# portal

Portal template with Vertical Slice Architecture using .NET, Blazor, Microservices, Aspire

## Overview

This is a modern cloud-native portal template built with:
- .NET 10 with C# 14
- Blazor Server & Blazor WebAssembly
- Vertical Slice Architecture
- .NET Aspire for orchestration
- Entity Framework Core 10
- Comprehensive testing framework

## Documentation

- **[Technology Stack](TECHNOLOGY_STACK.md)** - Complete list of technologies, versions, and configurations
- **[CLAUDE.md](CLAUDE.md)** - Development guidance and architecture details

## Quick Start

### Prerequisites
- .NET 10 SDK
- Node.js 20.x
- NPM 11.6.3+
- Docker (for Testcontainers and local development)

### Build
```bash
dotnet restore Portal.slnx
cd Frontend/Portal/src/Server && npm install && npm run build:css && cd ../../../..
dotnet build Portal.slnx
```

### Run
```bash
dotnet run --project Aspire/src/AppHost/Portal.Aspire.AppHost.csproj
```

### Test
```bash
dotnet test Portal.slnx
```

## CI/CD

The project includes CI/CD pipelines for:
- **GitHub Actions**: `.github/workflows/dotnet.yml`
- **GitLab CI**: `.gitlab-ci.yml`

## License

Copyright (c) 2014-2025 Sarin Na Wangkanai, All Rights Reserved.
