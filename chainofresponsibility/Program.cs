using System;

public abstract class Handler
{
    protected Handler next;

    public void setNext(Handler handler)
    {
        this.next = handler;
    }

    public abstract void handleRequest(Email email);
}

public class Spam:Handler
{
    public override void handleRequest(Email email)
    {
        if (email.getEmailtype() == 0)
        {
            Console.WriteLine("Spam\n");
            email.showMail();
        }
        else if (next != null) next.handleRequest(email);
    }
}

public class NormalEmail:Handler
{
    public override void handleRequest(Email email)
    {
        if (email.getEmailtype() == 1)
        {
            Console.WriteLine("Normal Email\n");
            email.showMail();
        }
        else if (next != null) next.handleRequest(email);
    }
}

public class Email
{
    string subject;
    string text;
    int emailType;

    public Email(string subject, string text, int etype)
    {
        this.subject = subject;
        this.text = text;
        this.emailType = etype;
    }

    public int getEmailtype()
    {
        return emailType;
    }

    public void showMail()
    {
        Console.WriteLine("Show message");
        Console.WriteLine(subject);
        Console.WriteLine(text);
        Console.WriteLine(emailType);
        Console.WriteLine();
    }
}


class Program
{
    static void Main(string[] args)
    {
        Handler spam = new Spam();
        Handler normal = new NormalEmail();

        spam.setNext(normal);
        Email email1 = new Email("First", "test", 1);
        spam.handleRequest(email1);
        Email email2 = new Email("Second", "test", 0);
        spam.handleRequest(email2);


        Console.ReadKey();
    }
}
