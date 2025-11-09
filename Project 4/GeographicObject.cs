namespace GeographyApp
{
    abstract class GeographicObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public abstract string GetInfoMethod();
    }
}
