# Object Calisthenics Violations

This document lists all deviations from the Object Calisthenics rules found in the codebase.

## Object Calisthenics Rules

For reference, the Object Calisthenics rules are:

1. One level of indentation per method
2. Don't use the ELSE keyword
3. Wrap all primitives and strings
4. First class collections
5. One dot per line
6. Don't abbreviate
7. Keep all entities small
8. No classes with more than two instance variables
9. No getters/setters/properties

## Violations by File

### Product.cs

- **Rule 3: Wrap all primitives and strings**
  - `Id`, `Name`, `Price`, and `Quantity` are all primitives that should be wrapped in their own types
  - Example fix: Create `ProductId`, `ProductName`, `Money`, and `Quantity` value objects

- **Rule 9: No getters/setters/properties**
  - All fields are exposed as public properties with getters and setters
  - Example fix: Replace with methods that express behavior rather than state

### VendingMachineService.cs

- **Rule 3: Wrap all primitives and strings**
  - `_balance` is a primitive decimal that should be wrapped
  - Example fix: Create a `Money` value object

- **Rule 4: First class collections**
  - `_products` is a raw `List<Product>` rather than a first-class collection
  - Example fix: Create a `ProductInventory` class that encapsulates the list and its operations

- **Rule 5: One dot per line**
  - Line 63: `_products.FirstOrDefault(p => p.Id == productId)`
  - Line 34: `return _products.ToList()`
  - Example fix: Extract methods to eliminate method chaining

- **Rule 9: No getters/setters/properties**
  - `GetBalance()` is essentially a getter method
  - `GetProducts()` returns the internal collection
  - Example fix: Replace with methods that express behavior rather than state

### Program.cs

- **Rule 1: One level of indentation per method**
  - `Main` method has multiple levels of indentation with the switch statement and nested if statements
  - Example fix: Extract methods for each level of logic

- **Rule 2: Don't use the ELSE keyword**
  - Line 92: `else` statement in `InsertMoney` method
  - Example fix: Use guard clauses and early returns

- **Rule 3: Wrap all primitives and strings**
  - `exit` boolean, `amount` decimal, and various string inputs are not wrapped
  - Example fix: Create domain-specific types for these values

- **Rule 5: One dot per line**
  - Line 20: `choice.ToUpper()`
  - Line 70: `Console.WriteLine($"{product.Id}\t{product.Name,-10}\t{product.Price:C}\t{product.Quantity}")`
  - Example fix: Extract methods to eliminate method chaining

- **Rule 8: Keep all entities small**
  - `Program` class has multiple responsibilities (UI, input handling, etc.)
  - Example fix: Split into smaller, focused classes

### VendingMachineServiceTests.cs

- **Rule 3: Wrap all primitives and strings**
  - `initialBalance`, `amountToInsert`, and other primitives are not wrapped
  - Example fix: Create domain-specific types for these values

- **Rule 5: One dot per line**
  - Line 54: `_vendingMachine.GetProducts().First(p => p.Id == productId)`
  - Example fix: Extract methods to eliminate method chaining

## General Recommendations

1. Create value objects for all primitives (strings, numbers, booleans)
2. Replace collections with first-class collection objects
3. Refactor methods to have only one level of indentation
4. Eliminate getters and setters in favor of behavior-expressing methods
5. Break down large classes into smaller, more focused ones
6. Use guard clauses instead of else statements
7. Extract methods to eliminate multiple dots per line