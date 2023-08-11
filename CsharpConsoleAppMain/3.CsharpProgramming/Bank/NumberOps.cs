namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public class NumbersWithoutComparable
{
    protected int baseTenNumber;
    public int BinaryNumber;
    public int RegularNumber;
}

public class Number : IComparable, IComparable<Number>
{
    protected int baseTenNumber;
    public int BinaryNumber;
    public int RegularNumber;

    public int CompareTo(object obj)
    {
        return obj == null
            ? 1
            : obj is Number otherNumber
                ? RegularNumber.CompareTo(otherNumber.RegularNumber)
                : throw new ArgumentException("Object is not a Temperature");
    }

    public int CompareTo(Number other)
    {
        return CompareTo(other);
    }
}