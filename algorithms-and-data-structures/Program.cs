﻿Dictionary<int, int> vendingMachine = new Dictionary<int, int>()
    {
        { 1, 15 },
        { 2, 12 },
        { 5, 5 },
        { 10, 4 },
        { 20, 1 }
    };

Dictionary<int, int>? Purchase(Dictionary<int, int> vendingMachine, int price, int payment)
{
    Dictionary<int, int> originalVendingMachine = new Dictionary<int, int>(vendingMachine);
    Dictionary<int, int> changes = new Dictionary<int, int>();
    int returnAmount = payment - price;

    // If the item price and the payment match, return a Dictionary with each key paired with 0.
    if (returnAmount == 0)
    {
        return vendingMachine.ToDictionary(e => e.Key, e => 0);
    }
    // If the payment is less than the item price, return null.
    else if (returnAmount < 0)
    {
        return null;
    }

    // Converts Dictionary to List in descending order of its Key so that higher coins can be calculated first.
    List<int> coins = vendingMachine.Select(e => e.Key).OrderByDescending((k) => k).ToList();
    foreach (int coin in coins)
    {
        int requiredNumberOfCoins = returnAmount / coin;

        if (requiredNumberOfCoins > 0)
        {
            if (vendingMachine[coin] - requiredNumberOfCoins >= 0)
            {
                changes[coin] = requiredNumberOfCoins;
                vendingMachine[coin] = vendingMachine[coin] - requiredNumberOfCoins;
            }
            else
            {
                changes[coin] = vendingMachine[coin];
                vendingMachine[coin] = 0;
            }
        }
        else
        {
            changes[coin] = 0;
        }

        returnAmount -= changes[coin] * coin;
    }

    // The vending machine does not have sufficient coins to return changes.
    if (returnAmount > 0)
    {
        // Reverts the changes.
        foreach (KeyValuePair<int, int> entry in originalVendingMachine)
        {
            vendingMachine[entry.Key] = originalVendingMachine[entry.Value];
        }
        return null;
    }

    return changes;
}


Console.WriteLine("Vending Machine Before Purchase:");
foreach (KeyValuePair<int, int> entry in vendingMachine)
{
    Console.WriteLine($"{entry.Key}: {entry.Value}");
}

Dictionary<int, int>? changes = Purchase(vendingMachine, 12, 55);

Console.WriteLine("\nVending Machine After Purchase:");
foreach (KeyValuePair<int, int> entry in vendingMachine)
{
    Console.WriteLine($"{entry.Key}: {entry.Value}");
}

if (changes != null)
{
    Console.WriteLine("\nChanges:");
    foreach (KeyValuePair<int, int> entry in changes.OrderBy(e => e.Key))
    {
        Console.WriteLine($"{entry.Key}: {entry.Value}");
    }
}
else
{
    Console.WriteLine("\nFailed to purchase");
}
