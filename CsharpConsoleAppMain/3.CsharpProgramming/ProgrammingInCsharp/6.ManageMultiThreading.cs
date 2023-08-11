using CsharpConsoleAppMain.CsharpProgramming.Bank;
using System.Diagnostics;

namespace CsharpConsoleAppMain.CsharpProgramming.ProgrammingInCsharp;

public static class ManageMultiThreadingogramFlow
{
    public static void ThrowVsRethrow()
    {
        ExceptionToaster testRethrow = new();
        try
        {
            ExceptionToaster.ExceptionPropagator();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }

        try
        {
            testRethrow.SendBankAsInnerException();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }

    public static void Locking()
    {
        Thread[] threads = new Thread[10];
        BankAccount acc = new(1000);
        for (int i = 0; i < 10; i++)
        {
            Thread t = new(acc.DoTransactions);
            threads[i] = t;
        }

        for (int i = 0; i < 10; i++)
        {
            threads[i].Start();
        }
    }

    public static void Synchronization()
    {
        resetter = new AutoResetEvent(false);

        Console.WriteLine("Main thread starting worker thread...");
        Thread thread_1 = new(AnotherThreadOfWork);
        thread_1.Start();

        Console.WriteLine("Main Thread sleeping for a second...");
        Thread.Sleep(1000);

        Console.WriteLine("Main Thread will now 'reactivate worker thread by using signaling (.SET method)");

        _ = resetter.Set();
    }

    public static void CancellationToken()
    {
        CancellationTokenSource tokenSource = new();
        CancellationToken cntkn = tokenSource.Token;

        Task task = Task.Factory.StartNew(() =>
        {
            cntkn.ThrowIfCancellationRequested();

            const bool DoTimeConsumingActivity = true;
            while (DoTimeConsumingActivity)
            {
                if (cntkn.IsCancellationRequested)
                {
                    //Throw exception to forcefully terminate this thread
                    cntkn.ThrowIfCancellationRequested();
                }

                Thread.Sleep(100);
                Console.WriteLine("-");
            }
        }, tokenSource.Token);

        _ = Console.ReadLine();
        tokenSource.Cancel();

        try
        {
            task.Wait();
        }
        catch (AggregateException e)
        {
            foreach (Exception ie in e.InnerExceptions)
            {
                Console.WriteLine($"{e.Message}:{ie.Message}");
            }
        }
    }

    public static void RaceConditions()
    {
        Worker objWorker = new();
        Thread t1 = new(objWorker.DoActivityOne);
        t1.Start();
        //syncronization
        //t1.Join();

        Thread t2 = new(objWorker.DoActivityTwo);
        t2.Start();
        //syncronization
        //t2.Join();

        _ = Console.ReadKey();
    }

    public static void ThreadSafeMethods()
    {
        SimpleSyncWithNumbers();
    }

    public static void TaskBasedAsynchronousProgramming()
    {
        Task t1 = Task.Factory.StartNew(delegate { _ = SomeActivity(1); });

        Task t5 = CreateTaskForAsyncActivity();
        t5.Start();
        Task<int> t2 = Task.Factory.StartNew(() => SomeActivity(2));

        Task<int> t3 = Task.Factory.StartNew(() => SomeActivity(3));
        Task<int> t4 = Task.Factory.StartNew(() => SomeActivity(4));
        Task.WaitAll(t1, t2, t3, t4);

        int ResultSum = t2.Result + t3.Result + t4.Result;

        Console.WriteLine("Do something after all Task Executed...");
        Console.WriteLine($"Sum is : {ResultSum}");
        _ = Console.ReadKey();
    }

    public static void ParallelInkvokeMethod()
    {
        DemoInvoke_Sequential();
        DemoInvoke_Parallel();
    }

    public static void UsingTheParallelForStatement()
    {
        Console.WriteLine("Using C# For Loop \n");
        Stopwatch sw = new();
        const int iterations = 250;

        sw.Start();
        for (int i = 0; i < iterations; i++)
        {
            Console.WriteLine("i = {0}, thread = {1}",
                i, Environment.CurrentManagedThreadId);
            Thread.Sleep(10);
        }

        sw.Stop();
        long syncElapsed = sw.ElapsedMilliseconds;

        Console.WriteLine("\nUsing Parallel.For \n");
        sw.Reset();
        sw.Start();
        ParallelLoopResult pResult = Parallel.For(0, iterations, i =>
        {
            Console.WriteLine("i = {0}, thread = {1}", i,
                Environment.CurrentManagedThreadId);
            Thread.Sleep(10);
        });

        //Stay  here until all the loop iterations complete
        while (!pResult.IsCompleted)
        {
            // Wait for 100 milliseconds so that the CPU can do other work
            Thread.Sleep(100);
        }

        sw.Stop();
    }

    public static void ParallelForEachMethod()
    {
        int[] data = LoadData(100);
        SequencialForEach(data);
        ParallelForEach(data);
    }

    public static void ThreadPool()
    {
        _ = System.Threading.ThreadPool.QueueUserWorkItem(ThreadProcA, "Demo 1");
        _ = System.Threading.ThreadPool.QueueUserWorkItem(ThreadProcB, "Demo 2");
        _ = System.Threading.ThreadPool.QueueUserWorkItem(ThreadProcC, "Demo 3");

        Console.WriteLine("Main Thread operation");
        Thread.Sleep(1000 * 10);

        Console.WriteLine("Main Thread Exits");
    }

    public static void UnblockUIWithTask()
    {
        // Method intentionally left empty.
    }

    public static void UsingParallelLinq()
    {
        // Method intentionally left empty.
    }

    public static void ConcurrentCollections()
    {
        // Method intentionally left empty.
    }

    public static void UsingAsyncAndAwaitKeywords()
    {
        // Method intentionally left empty.
    }

    public static void UsingTasks()
    {
        // Method intentionally left empty.
    }

    public static void ContinuationTasks()
    {
        // Method intentionally left empty.
    }

    #region helper code for Synchronization

    private static AutoResetEvent? resetter;

    private static void AnotherThreadOfWork()
    {
        Console.WriteLine("{0,50}", "Another Thread of Work has Started");
        _ = resetter.WaitOne();
        Console.WriteLine("{0,50}", "Another Thread of Work has been reactivated...");

        Thread.Sleep(1000); //Simulate some work finishing...
        Console.WriteLine("{0,50}", "Another Thread of Work is Now Finishing");
    }

    #endregion helper code for Synchronization

    #region Helper code for Thread Safe Mode

    private static void SimpleSyncWithNumbers()
    {
        bool goAgain = false;
        do
        {
            Thread aThread = new(DoSomeWork);
            Thread anotherThread = new(DoSomeWork);
            aThread.Start();
            anotherThread.Start();

            aThread.Join();
            anotherThread.Join();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Unsafes: {0}", CountOperations.UnsafeCounter);
            Console.WriteLine("Safes: {0}", CountOperations.SafeCounter);

            Console.Write("Go again? Y/N?");
            goAgain = string.Equals(Console.ReadLine(), "Y", StringComparison.OrdinalIgnoreCase);
        } while (goAgain);
    }

    private static void DoSomeWork()
    {
        for (int i = 0; i < 50000; i++)
        {
            _ = new CountOperations();
        }
    }

    #endregion Helper code for Thread Safe Mode

    #region helper code for TaskBasedAsynchronousProgramming

    public static int SomeActivity(int Number)
    {
        DoProcessHugeData(Number);
        Console.WriteLine("Activity Number {0} completed", Number);
        return Number * 10;
    }

    public static void DoProcessHugeData(int index)
    {
        for (long inc = 0; inc < 8000000 / (index + 1); inc++)
        {
            ProcessData(ref inc);
        }
    }

    public static void ProcessData(ref long Data)
    {
        Data += 1000;
        Data -= 1000;
        Data += 2000;
        Data -= 2000;
    }

    public static Task CreateTaskForAsyncActivity()
    {
        return new Task(() => Console.WriteLine("Independent Activity Executed...."));
    }

    #endregion helper code for TaskBasedAsynchronousProgramming

    #region helper code for ParallelInkvokeMethod

    private static void DemoInvoke_Sequential()
    {
        Console.WriteLine("-----Sequential Calls----");
        _ = Activity(1);
        _ = Activity(2);
        _ = Activity(3);
        _ = Activity(4);
    }

    private static void DemoInvoke_Parallel()
    {
        Console.WriteLine("----Parallel.Invoke Calls----");
        Parallel.Invoke(
            () => Activity(1),
            () => Activity(2),
            () => Activity(3),
            () => Activity(4)
        );
    }

    private static int Activity(int index)
    {
        DoSomeHugeCalculation(index);
        Console.WriteLine("Activity {0}", index);
        return index * 10;
    }

    private static void DoSomeHugeCalculation(int index)
    {
        for (long i = 0; i < 5000000 / (index + 1); i++)
        {
            ProcessData(ref i);
        }
    }

    #endregion helper code for ParallelInkvokeMethod

    #region Helper code for UsingTheParallelForStatement

    private static int[] LoadData(int size)
    {
        int[] data = new int[size];
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = i;
        }

        return data;
    }

    public static void SequencialForEach(int[] data)
    {
        Stopwatch sw = Stopwatch.StartNew();
        foreach (int value in data)
        {
            ProcessHugeData(value);
        }

        long elapsed = sw.ElapsedMilliseconds;
        Console.WriteLine("Sequential foreach: {0} milliseconds", elapsed);
    }

    public static void ParallelForEach(int[] data)
    {
        Stopwatch sw = Stopwatch.StartNew();
        _ = Parallel.ForEach(data, ProcessHugeData);
        long elapsed = sw.ElapsedMilliseconds;
        Console.WriteLine("Parallel foreach: {0} milliseconds", elapsed);
    }

    public static void ProcessHugeData(int Identifier)
    {
        for (long i = 0; i < 6000000 + (Identifier * 5000); i++)
        {
            ProcessData(ref i);
        }
    }

    #endregion Helper code for UsingTheParallelForStatement

    #region Helper code for ThreadPool

    public static void ThreadProcA(object stateInfo)
    {
        Console.WriteLine($"Task One, data Passed is {stateInfo}");
    }

    public static void ThreadProcB(object stateInfo)
    {
        Console.WriteLine($"Task Two, data Passed is {stateInfo}");
    }

    public static void ThreadProcC(object stateInfo)
    {
        Console.WriteLine($"Task Three, data Passed is {stateInfo}");
    }

    #endregion Helper code for ThreadPool
}

#region Helper code for ThrowVsRethrow

internal class ExceptionToaster
{
    public static void ExceptionPropagator()
    {
        // Method intentionally left empty.
    }

    public void SendBankAsInnerException()
    {
        Console.WriteLine("\n\nAnd now with an inner exception...");
        try
        {
            OurLittleFakeException();
        }
        catch (ArgumentNullException e)
        {
            throw new Exception("Something bad happened!", e);
        }
    }

    private static void OurLittleFakeException()
    {
        // Method intentionally left empty.
    }
}

#endregion Helper code for ThrowVsRethrow

#region Helper code for Race Conditions

internal class Worker
{
    private readonly object _lockObject = new();
    private readonly object _lockObject2 = new();
    private int data;

    public void DoActivityOne()
    {
        lock (_lockObject)
        {
            for (int inc = 0; inc < 100; inc++)
            {
                data++;
                Console.WriteLine($"Value of DATA is: {data} in thread id: {Environment.CurrentManagedThreadId}");
                Thread.Sleep(200);
            }
        }
    }

    public void DoActivityTwo()
    {
        lock (_lockObject2)
        {
            for (int inc = 0; inc < 100; inc++)
            {
                data += 10;
                Console.WriteLine($"Value of DATA is : {data} in thread id: {Environment.CurrentManagedThreadId}");
                Thread.Sleep(100);
            }
        }
    }
}

#endregion Helper code for Race Conditions

#region Helper code for Thread Safe Mode

internal class CountOperations
{
    private static int safes;

    public CountOperations()
    {
        UnsafeCounter++;
        _ = Interlocked.Increment(ref safes);
    }

    public static int UnsafeCounter { get; private set; }

    public static int SafeCounter => safes;

    ~CountOperations()
    {
        UnsafeCounter--;
        _ = Interlocked.Decrement(ref safes);
    }
}

#endregion Helper code for Thread Safe Mode