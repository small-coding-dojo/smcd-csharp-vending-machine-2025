# Vending Machine CLI Application

A simple C# console application that simulates a vending machine.

## Project Structure

- **VendingMachine.Core**: Contains the core business logic and models
  - `Product.cs`: Represents a product in the vending machine
  - `VendingMachineService.cs`: Service that handles vending machine operations

- **VendingMachine.CLI**: Contains the console application
  - `Program.cs`: Entry point for the CLI application

- **VendingMachine.Tests**: Contains unit tests
  - `VendingMachineServiceTests.cs`: Tests for the VendingMachineService

## Features

- Display available products
- Insert money
- Purchase products
- Return change
- Simple menu-driven interface

## How to Run

### Build the Application

```bash
dotnet build
```

### Run the Application

```bash
dotnet run --project VendingMachine.CLI
```

### Run the Tests

```bash
dotnet test
```

## Default Products

The vending machine is initialized with the following products:

- Cola (A1): $1.50
- Water (A2): $1.00
- Chips (B1): $1.25
- Chocolate (B2): $1.75

Each product has an initial quantity of 10.