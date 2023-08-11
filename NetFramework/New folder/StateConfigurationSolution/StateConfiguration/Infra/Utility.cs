using System.Runtime.InteropServices;

namespace StateConfiguration.Infra
{
    public static class Utility
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern char CharUpper(char character);


        public static string GetPlatformInfo()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var os = OSPlatform.Create(OSPlatform.Windows.ToString());

                OperatingSystem o = new OperatingSystem(PlatformID.Win32NT, new Version());

                return "OSPlatform.Windows";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return "OSPlatform.Linux";
            else throw new NotSupportedException();
        }
    }

    public static class UtilityCharWINDOWS
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern char CharUpper(char character);
    };

    public static class UtilityCharLINUX 
    {
        [DllImport("Actuallinuxlibrary.so", CharSet = CharSet.Auto)]
        public static extern char CharUpper(char character);
    }
}
