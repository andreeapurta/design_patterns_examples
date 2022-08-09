namespace FactoryPattern
{
    /// <summary>
    /// Concrete Product class
    /// </summary>
    internal class SamsungPhone : SmartPhone
    {
        public override string Type { get; }
        public override string Model { get; }

        public SamsungPhone(string model)
        {
            Model = model;
            Type = "Samsung";
        }
    }
}
