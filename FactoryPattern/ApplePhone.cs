namespace FactoryPattern
{
    /// <summary>
    /// Concrete Product class
    /// </summary>
    internal class ApplePhone : SmartPhone
    {
        public override string Type { get; }
        public override string Model { get; }

        public ApplePhone(string model)
        {
            Model = model;
            Type = "iPhone";
        }
    }
}
