using System;

public sealed class ConfigFiles
{
    static ConfigFiles myInstance = null;

    ConfigFiles() { }

    public static ConfigFiles instance
    {
        get
        {
            if (myInstance == null) myInstance = new ConfigFiles();
            return myInstance; 
        }
    }

    public void doSomething()
    {
        Console.WriteLine("Singleton\n");
    }
}

public class Application
{
    ConfigFiles configFiles;

    public Application()
    {
        configFiles=ConfigFiles.instance;
    }

    public void writeSomething()
    {
        configFiles.doSomething();
    }

}


class Program
{
    static void Main(string[] args)
    {
        Application application = new Application();
        application.writeSomething();
        Console.ReadKey();
    }
}
