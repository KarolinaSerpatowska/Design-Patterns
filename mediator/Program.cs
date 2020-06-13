using System;

interface IMediator
{
    void sendMessage(string message, User user);
}

class Chat:IMediator
{
    Moderator mod;
    SimpleUser user;

    public Moderator Moderator
    {
        set { mod = value; }
    }

    public SimpleUser SimpleUser
    {
        set { user = value; }
    }

    public void sendMessage(string message, User user)
    {
        if (user == mod) this.user.receiveMessage(message);
        else mod.receiveMessage(message);
    }
}


abstract class User
{
    protected IMediator mediator;

    public User(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public abstract void sendMessage(string message);
    public abstract void receiveMessage(string message);
}

class Moderator:User
{
    public Moderator(IMediator mediator) : base(mediator) { }

    public override void sendMessage(string message)
    {
        Console.WriteLine("Moderator send message");
        mediator.sendMessage(message, this);
    }

    public override void receiveMessage(string message)
    {
        Console.WriteLine("To moderator: {0}", message);
    }
}

class SimpleUser : User
{
    public SimpleUser(IMediator mediator) : base(mediator) { }

    public override void sendMessage(string message)
    {
        Console.WriteLine("User send message");
        mediator.sendMessage(message, this);
        
    }

    public override void receiveMessage(string message)
    {
        Console.WriteLine("To user: {0}", message);
    }
}



class Program
{
    static void Main(string[] args)
    {

        Chat chat = new Chat();
        SimpleUser user = new SimpleUser(chat);
        Moderator mod = new Moderator(chat);
        chat.Moderator = mod;
        chat.SimpleUser = user;

        mod.sendMessage("Message1");
        user.sendMessage("Message2");


        Console.ReadKey();
    }
}
