using System.Globalization;

namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public class Numerics : IFormattable
{
    private readonly decimal num;

    #region Methods for IFormattable

    public Numerics(decimal num)
    {
    }

    //public decimal NumWith2Decimals()
    //{
    //}
    //public decimal NumWith3Decimals()
    //{
    //}
    //public decimal NumWith4Decimals()
    //{
    //}
    public override string ToString()
    {
        return ToString("G", CultureInfo.CurrentCulture);
    }

    public string ToString(string format)
    {
        return ToString(format, CultureInfo.CurrentCulture);
    }

    public string ToString(string format, IFormatProvider provider)
    {
        if (string.IsNullOrEmpty(format))
        {
            format = "G";
        }

        provider ??= CultureInfo.CurrentCulture;

        return format.ToUpperInvariant() switch
        {
            "G" => num.ToString(),
            "T" or "U" => (num + 0.01M).ToString("F2", provider),
            "V" => (num + 0.001M).ToString("F2", provider),
            "W" => (num + 0.0001M).ToString("F2", provider),
            _ => throw new FormatException(string.Format("The {0} format string is not supported",
                format))
        };
    }

    #endregion Methods for IFormattable
}