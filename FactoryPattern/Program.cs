
using FactoryPattern;

static string ReadValueFromUser(string message)
{
    Console.WriteLine(message);
    string? value = Console.ReadLine();

    if (string.IsNullOrEmpty(value))
    {
        throw new OperationCanceledException();
    }

    return value;
}
try
{
    Courier Ana = new();
    string phoneType = ReadValueFromUser("Enter the phone type you would like to get:");
    SmartPhoneStore store = phoneType.ToLower() switch
    {
        "samsung" => new SamsungStore(Ana),
        "iphone" => new AppleStore(Ana),
        "huawei" => new HuaweiStore(Ana),
        _ => throw new Exception("Invalid phone"),
    };

    string phoneModel = ReadValueFromUser("Enter the phone model you would like to get:");
    string deliveryAddress = ReadValueFromUser("Enter the delivery address for your order:");
    string deliveryName = ReadValueFromUser("Enter the delivery name for your order:");

    store.DeliverSmartPhone(phoneModel, deliveryAddress, deliveryName);
}
catch (Exception e)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(e);
}