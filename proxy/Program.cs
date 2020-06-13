using System;

public interface IFolder
{
    void changeSomething(User user);
}

public class Folder:IFolder
{
    public Folder() { }

    public void changeSomething(User user)
    {
        Console.WriteLine("Folder: do something");
    }
}

public class FolderProxy: IFolder
{
    User user;
    Folder folder;

    public FolderProxy() { }

    public void changeSomething(User user)
    {
        if (user.permissions == "admin")
        {
            folder = new Folder();
            folder.changeSomething(user);
        }
        else Console.WriteLine("User don't have permission");
    }
}

public class User
{
    string name { get; }
    public string permissions { get; }

    public User(string name, string permissions)
    {
        this.name = name;
        this.permissions = permissions;
    }
}



class Program
{
    static void Main(string[] args)
    {
        User user1 = new User("user1", "admin");
        User user2 = new User("user2", "simple user");
        FolderProxy proxy = new FolderProxy();
        proxy.changeSomething(user1);
        proxy.changeSomething(user2);



        Console.ReadKey();
    }
}
