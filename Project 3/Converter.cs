using System;

class Converter
{
    public decimal UsdRate { get; set; }
    public decimal EurRate { get; set; }

    public Converter(decimal usdRate, decimal eurRate)
    {
        UsdRate = usdRate;
        EurRate = eurRate;
    }

    public decimal ConvertFromUah(decimal amount, string currency)
    {
        return currency.ToLower() switch
        {
            "usd" => amount / UsdRate,
            "eur" => amount / EurRate,
            _ => 0
        };
    }

    public decimal ConvertToUah(decimal amount, string currency)
    {
        return currency.ToLower() switch
        {
            "usd" => amount * UsdRate,
            "eur" => amount * EurRate,
            _ => 0
        };
    }
}
