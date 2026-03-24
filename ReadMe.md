# ResturantApplication

A comprehensive .NET-based restaurant management application built with a clean architecture approach.

## Overview

ResturantApplication is a C# solution designed to manage restaurant operations efficiently. The project follows a layered architecture pattern, separating concerns across multiple layers for maintainability and scalability.

## Project Structure

The solution is organized into the following main components:

### Source Code (`src/`)
- **ResturantApplication.Api** - REST API layer for handling HTTP requests and responses
- **ResturantApplication.Application** - Business logic and application services layer
- **ResturantApplication.Domain** - Core domain entities and business rules
- **ResturantApplication.Infastructure** - Data access, external services, and infrastructure implementations

### Tests (`tests/`)
- **ResturantApplication.Api.Tests** - Unit and integration tests for API layer
- **ResturantApplication.Application.Tests** - Tests for application services and business logic

## Technology Stack

- **Language:** C# (.NET)
- **Architecture:** Clean/Layered Architecture
- **Testing:** Comprehensive test coverage across multiple layers

## Getting Started

### Prerequisites

- .NET SDK (see `global.json` for required version)
- Visual Studio or Visual Studio Code
- Git

### Building the Project

```bash
# Clone the repository
git clone https://github.com/neeshabhattarai/ResturantApplication.git

# Navigate to source directory
cd src

# Restore dependencies
dotnet restore

# Build the solution
dotnet build ResturantApplication.sln

# Run tests
cd ../tests
dotnet test