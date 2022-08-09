using FactoryPattern;

static string ReadValueFromUser(string message)
{
    Console.WriteLine(message);
    string? value = Console.ReadLine();

    if (value == null)
    {
        throw new OperationCanceledException();
    }

    return value;
}

try
{
    Courier Alex = new();
    string phoneType = ReadValueFromUser("Enter the phone type you would like to get:");

    if (phoneType != null)
    {
        SmartPhoneStore store = phoneType.ToLower() switch
        {
            "iphone" => new AppleStore(Alex),
            "huawei" => new HuaweiStore(Alex),
            "samsung" => new SamsungStore(Alex),
            _ => throw new Exception("Invalid phone type"),
        };

        string phoneModel = ReadValueFromUser("Enter the phone model you would like to get:");
        string deliveryAddress = ReadValueFromUser("Enter the delivery address for your order:");
        string deliveryName = ReadValueFromUser("Enter the delivery name for your order:");

        store.DeliverSmartPhone(phoneModel, deliveryAddress, deliveryName);
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}

