using System.Text;

Dictionary<int, int> vendingMachine = new Dictionary<int, int>()
    {
        { 1, 15 },
        { 2, 12 },
        { 5, 5 },
        { 10, 4 },
        { 20, 1 }
    };

/*
 * Accepts coins and the number of each coin, the item price, and the money the customer paid. 
 * Calculates the change that should be returned to the customer. The change is a Dictionary
 * represents the number of each coin.
 */
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


/*
 * Accepts a string and converts every consecutive letter appeared more than twice
 * to the form of that letter followed by the number of occurences of that letter.
 */
String CompressString(String testString)
{
    List<char> consecutiveLetters = new List<char>();

    StringBuilder sb = new StringBuilder();

    foreach (char letter in testString)
    {
        if (consecutiveLetters.Count > 0 && consecutiveLetters.First() != letter)
        {
            if (consecutiveLetters.Count > 2)
            {
                sb.Append(consecutiveLetters.First() + $"{consecutiveLetters.Count}");
            }
            else
            {
                sb.Append(consecutiveLetters.Aggregate("", (p, c) => p + c));
            }

            consecutiveLetters.Clear();
        }

        consecutiveLetters.Add(letter);
    }

    if (consecutiveLetters.Count > 2)
    {
        sb.Append(consecutiveLetters.First() + $"{consecutiveLetters.Count}");
    }
    else
    {
        sb.Append(consecutiveLetters.Aggregate("", (p, c) => p + c));
    }


    return sb.ToString();
}

Console.WriteLine(CompressString("RTFFFFYYUPPPEEEUU"));

/*
 * Accepts an alphanumeric string and expands number to the consecutive letters that appeared before the number.
 */
String DecompressString(String testString)
{
    StringBuilder sb = new StringBuilder();

    foreach (char letter in testString)
    {
        if (char.IsDigit(letter))
        {
            sb.Append(new String(sb[sb.Length - 1], int.Parse(letter.ToString()) - 1));
        }
        else
        {
            sb.Append(letter);
        }
    }

    return sb.ToString();
}

Console.WriteLine(DecompressString("RTF4YYUP3E3UU"));
