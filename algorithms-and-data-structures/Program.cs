int GetNumberInput()
{
    return int.Parse(Console.ReadLine());
}

char GetCharacterInput()
{
    char character;
    do
    {
        character = Console.ReadKey().KeyChar;
        Console.WriteLine();
    } while (!char.IsLetter(character));

    return character;
}

string[] PopulateWordArray(int length)
{
    string[] words = new string[length];

    for (int i = 0; i < length; i++)
    {
        string input = Console.ReadLine();

        bool hasWhitespace = input.Any(v => char.IsWhiteSpace(v));
        if (hasWhitespace)
        {
            Environment.Exit(0);
        }

        words[i] = input;
    }

    return words;
}

int GetCharacterFrequency(string[] words, char character)
{
    int frequency = 0;

    foreach (string word in words)
    {
        foreach (char letter in word)
        {

            bool isEqual = char.ToUpperInvariant(letter) == char.ToUpperInvariant(character);

            if (isEqual)
            {
                frequency++;
            }
        }
    }

    return frequency;
}

int GetCharacterOccurrencePercentage(string[] words, char charToCount)
{
    int charCount = GetCharacterFrequency(words, charToCount);

    int totalCharCount = words.Aggregate(0, (prev, curr) => prev + curr.Count());

    return (int)(((double)charCount / (double)totalCharCount) * 100.0);
}

void PrintResults(char countedCharacter, int charFrequency, int charPercentage)
{
    string message = $"The letter ‘{countedCharacter}’ appears {charFrequency} times in the array.";

    if (charPercentage > 25)
    {
        message += " This letter makes up more than 25% of the total number of characters.";
    }

    Console.WriteLine(message);
}


Console.WriteLine("Please enter a number:");

int numberOfWords = GetNumberInput();


Console.WriteLine($"Please enter {numberOfWords} words:");

string[] words = PopulateWordArray(numberOfWords);

Console.WriteLine("Please enter a character:");

char character = GetCharacterInput();

int charPercentage = GetCharacterOccurrencePercentage(words, character);

PrintResults(character, GetCharacterFrequency(words, character), charPercentage);
