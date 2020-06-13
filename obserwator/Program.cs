using System;
using System.Collections.Generic;

public interface IObserver
{
    void doSomething(IWatched watched, float x, float y);
}

public interface IWatched
{
    void addObserver(IObserver observer);
    void removeObserver(IObserver observer);
    void updateObservers();
}

public class Player:IWatched
{
    List<IObserver> observers;
    float hp=100;
    float x = 0;
    float y = 0;

    public Player()
    {
        observers = new List<IObserver>();
    }

    public void addObserver(IObserver observer)
    {
        observers.Add(observer);
        Console.WriteLine("Added new observer\n");
    }

    public void removeObserver(IObserver observer)
    {
        observers.Remove(observer);
        Console.WriteLine("Added removed observer\n");
    }

    public void updateObservers()
    {
        foreach(var ob in observers)
        {
            ob.doSomething(this, x,y);
        }
    }

    public float getHp()
    {
        return hp;
    }

    public float getx()
    {
        return x;
    }

    public float gety()
    {
        return y;
    }

    public void changeXY(float a, float b)
    {
        x += a;
        y += b;
    }

}

public class Enemy:IObserver
{
    float x;
    float y;

    public Enemy(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public void doSomething(IWatched watched, float x, float y)
    {
        if (this.x-x<=5)
        Console.WriteLine("Enemy: Follow target");
    }
}

public class Trap:IObserver
{
    float x;
    float y;

    public Trap(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public void doSomething(IWatched watched, float x, float y)
    {
        if(this.x==x && this.y==y)
        Console.WriteLine("Trap: Kill player");
    }
}

public class Npc : IObserver
{
    public Npc() { }

    public void doSomething(IWatched watched, float x, float y)
    {
        Console.WriteLine("Npc: Talk to player");
    }
}



class Program
{
   static void Main(string[] args)
   {
        Player player = new Player();
        Enemy enemy1 = new Enemy(10,10);
        Enemy enemy2 = new Enemy(5,5);
        player.addObserver(enemy1);
        player.addObserver(enemy2);
        Npc npc = new Npc();
        player.addObserver(npc);
        for(int i=0;i<=10;i++)
        {
            Trap t = new Trap(10,i);
            player.addObserver(t);
        }

        player.updateObservers();

        player.changeXY(10, 10);

        player.updateObservers();

        Console.ReadKey();
   }
}
