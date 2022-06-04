List<int> MaxNumbersInLists(List<List<int>> listOfList)
{
    return listOfList.Aggregate(new List<int>(), (prev, curr) => prev.Append(curr.Max()).ToList());
}

List<int> results = MaxNumbersInLists(new List<List<int>> { new List<int> { 1, 5, 3 }, new List<int> { 9, 7, 3, -2 }, new List<int> { 2, 1, 2 } });
Console.WriteLine($"List 1 has a maximum of {results[0]}. List 2 has a maximum of {results[1]}. List 3 has a maximum of {results[2]}.");


String HighestGrade(List<List<int>> listOfList)
{
    int highestGrade = listOfList.Aggregate(0, (prev, curr) => Math.Max(prev, curr.Max()));
    List<int> classes = new List<int>();

    for (int i = 0; i < listOfList.Count; i++)
    {
        if (listOfList[i].Contains(highestGrade))
        {
            classes.Add(i);
        }
    }


    return $"The highest grade is {highestGrade}. This grade was found in class{(classes.Count > 1 ? "es" : "")} {String.Join(", ", classes)}";
}

Console.WriteLine(HighestGrade(new List<List<int>> { new List<int> { 85, 92, 67, 94, 94 }, new List<int> { 50, 60, 57, 95 }, new List<int> { 95 } }));


List<int> OrderByLooping(List<int> list)
{
    bool swapped;

    do
    {
        swapped = false;

        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i] > list[i + 1])
            {
                int v = list[i];
                list[i] = list[i + 1];
                list[i + 1] = v;
                swapped = true;
            }
        }
    } while (swapped);

    return list;
}

foreach (int element in OrderByLooping(new List<int> { 6, -2, 5, 3 }))
{
    Console.WriteLine(element);
}
