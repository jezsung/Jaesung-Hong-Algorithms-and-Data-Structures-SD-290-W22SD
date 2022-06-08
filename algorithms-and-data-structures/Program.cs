bool[][] relationships = new bool[][]
{
    new bool[] { true, true, true, false },
    new bool[] { false, true, true, false },
    new bool[] { false, false, true, false },
    new bool[] { true, true, true, true }
};


int FindFamousPerson(bool[][] relationships)
{

    for (int i = 0; i < relationships.Length; i++)
    {
        bool dontKnowEveryone = true;
        bool knownByEveryone = true;

        for (int j = 0; j < relationships[i].Length; j++)
        {
            if ((relationships[i][j] && i != j) || (!relationships[i][j] & i == j))
            {
                dontKnowEveryone = false;
                break;
            }

            if (!relationships[j][i])
            {
                knownByEveryone = false;
                break;
            }
        }

        if (dontKnowEveryone && knownByEveryone)
        {
            return i;
        }
    }

    return -1;
}

Console.WriteLine(FindFamousPerson(relationships));
