namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public class PseudoPoint : IConvertible
{
    private readonly double x;
    private readonly double y;

    public PseudoPoint(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public TypeCode GetTypeCode()
    {
        return TypeCode.Object;
    }

    bool IConvertible.ToBoolean(IFormatProvider? provider)
    {
        return x != 0.0 || y != 0.0;
    }

    byte IConvertible.ToByte(IFormatProvider provider)
    {
        return Convert.ToByte(GetDoubleValue());
    }

    char IConvertible.ToChar(IFormatProvider provider)
    {
        return Convert.ToChar(GetDoubleValue());
    }

    DateTime IConvertible.ToDateTime(IFormatProvider? provider)
    {
        return Convert.ToDateTime(GetDoubleValue());
    }

    decimal IConvertible.ToDecimal(IFormatProvider? provider)
    {
        return Convert.ToDecimal(GetDoubleValue());
    }

    string IConvertible.ToString(IFormatProvider? provider)
    {
        return string.Format("X: {0}, Y: {1})", x, y);
    }

    double IConvertible.ToDouble(IFormatProvider? provider)
    {
        return Convert.ToDouble(GetDoubleValue());
    }

    short IConvertible.ToInt16(IFormatProvider? provider)
    {
        return Convert.ToInt16(GetDoubleValue());
    }

    int IConvertible.ToInt32(IFormatProvider? provider)
    {
        return Convert.ToInt32(GetDoubleValue());
    }

    long IConvertible.ToInt64(IFormatProvider? provider)
    {
        return Convert.ToInt64(GetDoubleValue());
    }

    sbyte IConvertible.ToSByte(IFormatProvider? provider)
    {
        return Convert.ToSByte(GetDoubleValue());
    }

    float IConvertible.ToSingle(IFormatProvider? provider)
    {
        return Convert.ToSingle(GetDoubleValue());
    }

    object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
    {
        return Convert.ChangeType(GetDoubleValue(), conversionType);
    }

    ushort IConvertible.ToUInt16(IFormatProvider? provider)
    {
        return Convert.ToUInt16(GetDoubleValue());
    }

    uint IConvertible.ToUInt32(IFormatProvider? provider)
    {
        return Convert.ToUInt32(GetDoubleValue());
    }

    ulong IConvertible.ToUInt64(IFormatProvider? provider)
    {
        return Convert.ToUInt64(GetDoubleValue());
    }

    private double GetDoubleValue()
    {
        return Math.Sqrt((x * x) + (y * y));
    }
}