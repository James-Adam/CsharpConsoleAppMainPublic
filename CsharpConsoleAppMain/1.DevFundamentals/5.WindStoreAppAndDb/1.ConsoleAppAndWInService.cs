namespace CsharpConsoleAppMain.DevFundamentals.WindStoreAppAndDb;

public static class ConsoleAppAndWinService
{
    public static void consoleAppAndWinService()
    {
        //use InstallUtil.exe
        //Common commands include = STOP, START, PAUSE, RESUME
        //Key differences =
        //Run prior to user logon,
        //Install and start,
        //Attach a debugger,
        //Install and register a service,
        //Entry in services control manager,
        //Main method must have run
        //which users?
    }

    [STAThread]
    public static void WorkerService()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(new WorkerService());
    }
}