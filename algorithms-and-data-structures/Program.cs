Console.WriteLine("Please enter a number:");

int numberOfWords = int.Parse(Console.ReadLine());


Console.WriteLine($"Please enter {numberOfWords} words:");

string[] words = new string[numberOfWords];

for (int i = 0; i < numberOfWords; i++)
{
    string input = Console.ReadLine();


    bool hasWhitespace = input.Any(v => Char.IsWhiteSpace(v));
    if (hasWhitespace)
    {
        Console.WriteLine("Whitespaces are not allowed.");
        Environment.Exit(0);
    }

    words[i] = input;
}


Console.WriteLine("Please enter a character:");

char character;
do
{
    character = Console.ReadKey().KeyChar;
    Console.WriteLine();
} while (!char.IsLetter(character));



int count = 0;
foreach (string word in words)
{
    foreach (char letter in word)
    {

        bool isEqual = char.ToUpperInvariant(letter) == char.ToUpperInvariant(character);

        if (isEqual)
        {
            count++;
        }
    }
}


int totalLetterCount = words.Aggregate(0, (prev, curr) => prev + curr.Count());

if (((double)count / (double)totalLetterCount) * 100.0 > 25.0)
{
    Console.WriteLine($"The letter ‘{character}’ appears {count} times in the array. This letter makes up more than 25% of the total number of characters.");
}
else
{
    Console.WriteLine($"The letter ‘{character}’ appears {count} times in the array.");
}
