using System;
using System.Collections.Generic;

public abstract class EnemyPrototype
{
    string name;

    public EnemyPrototype(string name) { this.name = name; }

    public string getName
    {
        get { return name; }
    }

    public abstract void attack();
    public abstract EnemyPrototype clone();
}

public class Enemy:EnemyPrototype
{
    public Enemy(string name) : base(name) { }

    public override void attack()
    {
        Console.WriteLine("{0} attack", this.getName);
    }

    public override EnemyPrototype clone()
    {
        return (EnemyPrototype)this.MemberwiseClone();
    }
}

public class SpawnPoint
{
    List<EnemyPrototype> enemies; 
    public SpawnPoint(int number)
    {
        enemies = new List<EnemyPrototype>();
        enemies.Add(new Enemy("alien1"));
        for(int i=2;i<=number;i++)
        {
            enemies.Add(new Enemy("alien" + i));
        }
    }

    public List<EnemyPrototype> getEnemiesList
    {
        get { return enemies; }
    }
}



class Program
{
    static void Main(string[] args)
    {
        SpawnPoint spawnPoint = new SpawnPoint(10);
        var enemies = spawnPoint.getEnemiesList;
        foreach(var e in enemies)
        {
            e.attack();
        }

        Console.ReadKey();
    }
}
