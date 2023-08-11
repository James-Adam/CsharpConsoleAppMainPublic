namespace CsharpConsoleAppMain.DevFundamentals.DevWindAndWebApp;

public static class WindFormsExecute
{
    [STAThread]
    public static void CreatingTabbedPages()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        //ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(new CreatingTabbedPages());
    }

    public static void SavingFiles()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration. ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(new SavingFiles());
    }

    public static void OpeningFiles()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration. ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(new OpeningFiles());
    }

    public static void CreateDropdownMenu()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration. ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(new CreateDropdownMenu());
    }

    public static void MultiDocInterfaceApp()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration. ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(new MultiDocInterfaceApp());
    }

    public static void CreateToolbar()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration. ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        Application.Run(new CreateToolbar());
    }
}