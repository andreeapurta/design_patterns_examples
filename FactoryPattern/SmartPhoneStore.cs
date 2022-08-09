namespace FactoryPattern
{
    /// <summary>
    /// Creator abstract classs
    /// </summary>
    public abstract class SmartPhoneStore
    {
        private readonly Courier courier;

        public SmartPhoneStore(Courier courier)
        {
            this.courier = courier ?? throw new ArgumentNullException(nameof(courier));
        }

        public void DeliverSmartPhone(string phoneModel, string streetAddress, string personName)
        {
            SmartPhone smartPhone = CreateSmartPhone(phoneModel);
            courier.SendPackage(smartPhone, streetAddress, personName);
        }

        public abstract SmartPhone CreateSmartPhone(string phoneModel);
    }
}
