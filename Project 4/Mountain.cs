namespace GeographyApp
{
    class Mountain : GeographicObject
    {
        public string HighestPoint { get; set; }

        public override string GetInfoMethod()
        {
            return $"Mountain {Name}: Highest point - {HighestPoint}.";
        }
    }
}
