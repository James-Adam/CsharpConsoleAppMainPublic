using System.Diagnostics;

namespace CsharpConsoleAppMain.WebFundamentals;

public static class WebFundamentalsClass
{
    public static void webFundamentalsMethod()
    {
        _ = Process.Start(
            new ProcessStartInfo(
                    @"C:\inetpub\wwwroot\CsharpConsoleAppMainSolution\CsharpConsoleAppMain\2.WebFundamentals\html\about.html")
            { UseShellExecute = true });
    }
}