# Vending Machine CLI Application

[Kata Description](./KataDescription.md)

A simple C# console application that simulates a vending machine.

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

### Test Mutations with Stryker .NET

```bash
# Install the stryker dotnet tool
dotnet tool restore

# Test mutations
dotnet stryker
```
