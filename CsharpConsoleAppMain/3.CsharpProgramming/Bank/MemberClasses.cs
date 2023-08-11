using System.Collections;

namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public class Member
{
    public string CompanyAffiliation;
    public string CV_Info;

    public Member(string affiliation, string cv)
    {
        CompanyAffiliation = affiliation;
        CV_Info = cv;
    }
}

public class Members : IEnumerable
{
    private readonly Member[] members;

    public Members(Member[] mArray)
    {
        members = new Member[mArray.Length];
        Array.Copy(mArray, members, mArray.Length);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public MemberEnum GetEnumerator()
    {
        return new MemberEnum(members);
    }
}

public class MemberEnum : IEnumerator
{
    public Member[] members;
    private int position = -1;

    public MemberEnum(Member[] list)
    {
        members = list;
    }

    public Member Current
    {
        get
        {
            try
            {
                return members[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public bool MoveNext()
    {
        position++;
        Console.WriteLine("Postion from within MoveNext: {0} ", position);
        return position < members.Length;
    }

    public void Reset()
    {
        throw new NotSupportedException("This reset method cannot be called.");
    }

    object IEnumerator.Current => Current;
}