
namespace FactoryPattern
{
    /// <summary>
    /// Concrete Creator class
    /// </summary>
    internal class HuaweiStore : SmartPhoneStore
    {
        public HuaweiStore(Courier courier) : base(courier)
        {
        }

        public override SmartPhone CreateSmartPhone(string phoneModel)
        {
            return new HuaweiPhone(phoneModel);
        }
    }
}
