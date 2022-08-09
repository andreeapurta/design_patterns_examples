namespace FactoryPattern
{
    /// <summary>
    /// Concrete Creator class
    /// </summary>
    internal class SamsungStore : SmartPhoneStore
    {
        public SamsungStore(Courier courier) : base(courier)
        {
        }

        public override SmartPhone CreateSmartPhone(string phoneModel)
        {
            return new SamsungPhone(phoneModel);
        }
    }
}
