namespace CsharpConsoleAppMain.CsharpProgramming.Bank;

public class Resource : IDisposable
{
    private readonly System.Data.SqlClient.SqlConnection obj = new();
    private bool disposed;
    private IntPtr handle;

    //The class constructor.
    public Resource(IntPtr handle)
    {
        this.handle = handle;
        Console.WriteLine("Instantiated object {0}", this.handle.ToInt32());
    }

    public void Dispose() //client callable method
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing) //overload - garbage collection called
    {
        Console.WriteLine("Finalizing object {0}", handle.ToInt32());

        if (disposed)
        {
            if (disposing)
            {
                obj.Dispose();
            }

            handle = IntPtr.Zero;

            disposed = true;
        }
    }

    ~Resource()
    {
        Dispose(false);
    }
}