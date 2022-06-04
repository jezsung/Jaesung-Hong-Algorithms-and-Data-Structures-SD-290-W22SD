using System.Text.RegularExpressions;

Dictionary<int, string> InitializeCarPark(int capacity)
{
    Dictionary<int, string> carPark = new Dictionary<int, string>();

    for (int i = 0; i < capacity; i++)
    {
        carPark.Add(i + 1, null);
    }

    return carPark;
}

int AddVehicle(Dictionary<int, string> carPark, string licence)
{
    if (!carPark.ContainsValue(null) || !IsValidLicence(licence))
    {
        return -1;
    }

    int stall = carPark.First((e) => e.Value == null).Key;

    carPark[stall] = licence;

    return stall;
}

bool VacateStall(Dictionary<int, string> carPark, int stallNumber)
{
    if (!carPark.ContainsKey(stallNumber) || carPark[stallNumber] == null)
    {
        return false;
    }

    carPark[stallNumber] = null;

    return true;
}

bool LeaveParkade(Dictionary<int, string> carPark, string licenceNumber)
{
    if (!IsValidLicence(licenceNumber))
    {
        return false;
    }

    if (!carPark.ContainsValue(licenceNumber))
    {
        return false;
    }

    int stallNumber = carPark.First(e => e.Value == licenceNumber).Key;

    carPark[stallNumber] = null;

    return true;
}

String Manifest(Dictionary<int, string> carPark)
{
    return "{ " + String.Join(", ", carPark.Select(e => $"{e.Key}: {(e.Value != null ? $"\"{e.Value}\"" : "null") }")) + " }";
}

bool IsValidLicence(string licence)
{
    string pattern = @"[a-zA-Z0-9]{3}-[a-zA-Z0-9]{3}";

    Regex rg = new Regex(pattern);

    return rg.IsMatch(licence);
}

Dictionary<int, string> carPark = InitializeCarPark(3);
Console.WriteLine(Manifest(carPark));

AddVehicle(carPark, "A1A-00V");
AddVehicle(carPark, "AAA721");
Console.WriteLine(Manifest(carPark));

AddVehicle(carPark, "789-30A");
Console.WriteLine(Manifest(carPark));

VacateStall(carPark, 1);
Console.WriteLine(Manifest(carPark));

LeaveParkade(carPark, "789-30A");
Console.WriteLine(Manifest(carPark));
