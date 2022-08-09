namespace FactoryPattern
{
    public class Courier
    {
        public void SendPackage(SmartPhone smartPhone, string streetAddress, string personName)
        {
            string smartPhoneInfo = smartPhone.Type + " " + smartPhone.Model;
            Console.WriteLine("I got the product {0} and I wil deliver it to {1} at address {2}", smartPhoneInfo, personName, streetAddress);
        }
    }
}