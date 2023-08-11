﻿#define TRACE

using System.Diagnostics;

namespace CsharpConsoleAppMain.CsharpProgramming.ProgrammingInCsharp;

public static class TraceListenerClass
{
    // Define a simple method to write details about the current executing environment to the
    // trace listener collection.
    public static void WriteEnvironmentInfoToTrace()
    {
        const string methodName = "WriteEnvironmentInfoToTrace";

        Trace.Indent();
        Trace.WriteLine(DateTime.Now + " - Start of " + methodName);
        Trace.Indent();

        // Write details on the executing environment to the trace output.
        Trace.WriteLine("Operating system: " + Environment.OSVersion);
        Trace.WriteLine("Computer name: " + Environment.MachineName);
        Trace.WriteLine("User name: " + Environment.UserName);
        Trace.WriteLine("CLR runtime version: " + Environment.Version);
        Trace.WriteLine("Command line: " + Environment.CommandLine);

        // Enumerate the trace listener collection and display details about each configured
        // trace listener.
        Trace.WriteLine("Number of configured trace listeners = " + Trace.Listeners.Count);

        foreach (TraceListener tl in Trace.Listeners)
        {
            Trace.WriteLine("               type = " + tl.GetType());
        }

        Trace.Unindent();
        Trace.WriteLine(DateTime.Now + " - End of " + methodName);
        Trace.Unindent();
    }

    // Define the main entry point of this class. The main method adds a console trace listener
    // to the collection of configured trace listeners, then writes details on the current
    // executing environment.
    public static void MainTrace(string[] CmdArgs)
    {
        // Write a trace message to all configured trace listeners.
        Trace.WriteLine(DateTime.Now + " - Start of Main");

        // Define a trace listener to direct trace output from this method to the console.
        ConsoleTraceListener consoleTracer;

        // Check the command line arguments to determine which console stream should be used for
        // trace output.
        if (CmdArgs.Length > 0 && CmdArgs[0].Equals("/stderr", StringComparison.OrdinalIgnoreCase))
        {
            // Initialize the console trace listener to write trace output to the standard error stream.
            consoleTracer = new ConsoleTraceListener(true);
        }
        else
        {
            // Initialize the console trace listener to write trace output to the standard
            // output stream.
            consoleTracer = new ConsoleTraceListener();
        }

        // Set the name of the trace listener, which helps identify this particular instance
        // within the trace listener collection.
        consoleTracer.Name = "mainConsoleTracer";

        // Write the initial trace message to the console trace listener.
        consoleTracer.WriteLine(DateTime.Now + " [" + consoleTracer.Name +
                                "] - Starting output to trace listener.");

        // Add the new console trace listener to the collection of trace listeners.
        _ = Trace.Listeners.Add(consoleTracer);

        // Call a local method, which writes information about the current execution environment
        // to the configured trace listeners.
        WriteEnvironmentInfoToTrace();

        // Write the final trace message to the console trace listener.
        consoleTracer.WriteLine(DateTime.Now + " [" + consoleTracer.Name +
                                "] - Ending output to trace listener.");

        // Flush any pending trace messages, remove the console trace listener from the
        // collection, and close the console trace listener.
        Trace.Flush();
        Trace.Listeners.Remove(consoleTracer);
        consoleTracer.Close();

        // Write a final trace message to all trace listeners.
        Trace.WriteLine(DateTime.Now + " - End of Main");

        // Close all other configured trace listeners.
        Trace.Close();
    }
}