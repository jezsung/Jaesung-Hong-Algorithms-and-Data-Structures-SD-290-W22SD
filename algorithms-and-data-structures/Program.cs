bool IsPalindrome(string testString)
{
    if (testString.Contains(' '))
    {
        return false;
    }

    if (testString.Length % 2 != 1)
    {
        return false;
    }

    for (int i = 0; i < testString.Length; i++)
    {
        if (char.ToUpperInvariant(testString[i]) != char.ToUpperInvariant(testString[testString.Length - 1 - i]))
        {
            return false;
        }
    }

    return true;
}

char[] DuplicateCharacters(string testString)
{
    Dictionary<char, int> charCounts = new Dictionary<char, int>();

    foreach (char character in testString)
    {
        if (charCounts.ContainsKey(character))
        {
            charCounts[character] += 1;
        }
        else
        {
            charCounts.Add(character, 1);
        }
    }

    return charCounts.Where((e) => e.Value > 1).Select((e) => e.Key).ToArray();
}

string[] UniqueWords(string testString)
{
    string[] words = testString.Split();

    return words.Select(word => word.ToLower()).Distinct().ToArray();
}

Console.WriteLine("Test IsPalindrome()");
Console.WriteLine("");

Console.WriteLine(IsPalindrome("Ra cecar"));
Console.WriteLine(IsPalindrome("raDar"));
Console.WriteLine(IsPalindrome("rotator"));
Console.WriteLine(IsPalindrome("tomato"));
Console.WriteLine(IsPalindrome("des k"));
Console.WriteLine(IsPalindrome("Hello"));


Console.WriteLine("");
Console.WriteLine("Test DuplicateCharacters()");
Console.WriteLine("");

foreach (char character in DuplicateCharacters("Programmatic Python"))
{
    Console.WriteLine(character);
}

Console.WriteLine("");
Console.WriteLine("Test UniqueWords()");
Console.WriteLine("");

foreach (string word in UniqueWords("To be or not to be"))
{
    Console.WriteLine(word);
}
