namespace GeographyApp
{
    class River : GeographicObject
    {
        public double FlowSpeed { get; set; }  
        public double TotalLength { get; set; } 

        public override string GetInfoMethod()
        {
            return $"River {Name}: FlowSpeed = {FlowSpeed} cm/s, Length = {TotalLength} km.";
        }
    }
}
