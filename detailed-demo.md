# Detailed Vending Machine CLI Demonstration

This document shows the step-by-step interaction to purchase 2 bottles of Cola and a package of Chips using our Vending Machine CLI.

## Initial State

When the application starts, you'll see:

```
Welcome to the Vending Machine CLI!
Current Balance: $0.00

Please select an option:
1. Display Products
2. Insert Money
3. Purchase Product
4. Return Change
Q. Quit

Your choice: 
```

## Step 1: View Available Products

Input: `1`

Expected Output:
```
Available Products:
ID      Name            Price   Quantity
----------------------------------------
A1      Cola            $1.50   10
A2      Water           $1.00   10
B1      Chips           $1.25   10
B2      Chocolate       $1.75   10

Press any key to continue...
```

## Step 2: Insert Money

Input: `2`

Expected Output:
```
Insert Money:
Valid amounts: 0.25, 0.50, 1.00, 2.00, 5.00
Enter amount: 
```

Input: `5.00`

Expected Output:
```
Added $5.00. New balance: $5.00

Press any key to continue...
```

## Step 3: Purchase First Cola

Input: `3`

Expected Output:
```
Available Products:
ID      Name            Price   Quantity
----------------------------------------
A1      Cola            $1.50   10
A2      Water           $1.00   10
B1      Chips           $1.25   10
B2      Chocolate       $1.75   10

Enter product ID to purchase: 
```

Input: `A1`

Expected Output:
```
Dispensing Cola. Remaining balance: $3.50

Press any key to continue...
```

## Step 4: Purchase Second Cola

Input: `3`

Expected Output:
```
Available Products:
ID      Name            Price   Quantity
----------------------------------------
A1      Cola            $1.50   9
A2      Water           $1.00   10
B1      Chips           $1.25   10
B2      Chocolate       $1.75   10

Enter product ID to purchase: 
```

Input: `A1`

Expected Output:
```
Dispensing Cola. Remaining balance: $2.00

Press any key to continue...
```

## Step 5: Purchase Chips

Input: `3`

Expected Output:
```
Available Products:
ID      Name            Price   Quantity
----------------------------------------
A1      Cola            $1.50   8
A2      Water           $1.00   10
B1      Chips           $1.25   10
B2      Chocolate       $1.75   10

Enter product ID to purchase: 
```

Input: `B1`

Expected Output:
```
Dispensing Chips. Remaining balance: $0.75

Press any key to continue...
```

## Step 6: Get Change

Input: `4`

Expected Output:
```
Returned change: $0.75

Press any key to continue...
```

## Step 7: Exit

Input: `Q`

Expected Output:
```
Thank you for using the Vending Machine. Goodbye!
```

## Summary of Purchases

- 2 bottles of Cola ($1.50 each)
- 1 package of Chips ($1.25)
- Total spent: $4.25
- Change received: $0.75