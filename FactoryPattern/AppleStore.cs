namespace FactoryPattern
{
    /// <summary>
    /// Concrete Creator class
    /// </summary>
    internal class AppleStore : SmartPhoneStore
    {
        public AppleStore(Courier courier) : base(courier)
        {
        }

        public override SmartPhone CreateSmartPhone(string phoneModel)
        {
            return new ApplePhone(phoneModel);
        }
    }
}
