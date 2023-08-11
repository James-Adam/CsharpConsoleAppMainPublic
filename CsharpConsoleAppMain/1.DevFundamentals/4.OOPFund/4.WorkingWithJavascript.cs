using System.Diagnostics;

namespace CsharpConsoleAppMain.DevFundamentals.OOPFund;

public static class WorkingWithJavascript
{
    public static void workingWithJavascript()
    {
        _ = Process.Start(
            new ProcessStartInfo(
                    @"C:\inetpub\wwwroot\CsharpConsoleAppMain.Net\1.DevFundamentals\4.OOPFund\IntroToJavascript.html")
            { UseShellExecute = true });
    }
}