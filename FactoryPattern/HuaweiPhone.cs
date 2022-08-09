
namespace FactoryPattern
{
    /// <summary>
    /// Concrete Product class
    /// </summary>
    internal class HuaweiPhone : SmartPhone
    {
        public override string Type { get; }
        public override string Model { get; }

        public HuaweiPhone(string model)
        {
            Model = model;
            Type = "huawei";
        }
    }
}
