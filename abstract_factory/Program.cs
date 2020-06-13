using System;
using System.Collections.Generic;

public abstract class IFriendly
{
    public abstract void doSomething();
}

public abstract class IEnemy
{
    public float hp;
    public float dmg;
    public abstract void attack();
}

public class WeaponMerchant:IFriendly
{
    public override void doSomething()
    {
        Console.WriteLine("Merchant: sell item");
    }
}

public class QuestGiver:IFriendly
{
    public override void doSomething()
    {
        Console.WriteLine("Quest giver: give quest");
    }
}

public class ThiefEnemy:IEnemy
{
    public ThiefEnemy()
    {
        hp = 20;
        dmg = 70;
    }

    public override void attack()
    {
        Console.WriteLine("Thief attack {0}",dmg);
    }
}

public class FighterEnemy : IEnemy
{
    public FighterEnemy()
    {
        hp = 100;
        dmg = 30;
    }

    public override void attack()
    {
        Console.WriteLine("Fighter attack {0}", dmg);
    }
}

public abstract class IEntityFactory
{
    public abstract IEnemy createEnemy();
    public abstract IFriendly createFriendlyNPC();
}

public class ThievesGuildFactory:IEntityFactory
{
    public override IEnemy createEnemy()
    {
        return new ThiefEnemy();
    }

    public override IFriendly createFriendlyNPC()
    {
        return new QuestGiver();
    }
}

public class FighterGuildFactory:IEntityFactory
{
    public override IEnemy createEnemy()
    {
        return new FighterEnemy();
    }

    public override IFriendly createFriendlyNPC()
    {
        return new WeaponMerchant();
    }
}

public class ThievesGuild
{
    ThievesGuildFactory thievesGuildfactory;
    List<IEnemy> enemies;
    List<IFriendly> friendlies;


    public ThievesGuild(int number)
    {
        enemies = new List<IEnemy>();
        friendlies = new List<IFriendly>();
        thievesGuildfactory = new ThievesGuildFactory();
        for(int i=0;i<number;i++)
        {
            enemies.Add(thievesGuildfactory.createEnemy());
        }
        friendlies.Add(thievesGuildfactory.createFriendlyNPC());
    }

    public void talk()
    {
        foreach(var f in friendlies)
        {
            f.doSomething();
        }
    }

    public void attack()
    {
        foreach(var e in enemies)
        {
            e.attack();
        }
    }
}

public class FighterGuild
{
    FighterGuildFactory fighterGuildfactory;
    List<IEnemy> enemies;
    List<IFriendly> friendlies;


    public FighterGuild(int number)
    {
        enemies = new List<IEnemy>();
        friendlies = new List<IFriendly>();
        fighterGuildfactory = new FighterGuildFactory();
        for (int i = 0; i < number; i++)
        {
            enemies.Add(fighterGuildfactory.createEnemy());
        }
        friendlies.Add(fighterGuildfactory.createFriendlyNPC());
    }

    public void talk()
    {
        foreach (var f in friendlies)
        {
            f.doSomething();
        }
    }

    public void attack()
    {
        foreach (var e in enemies)
        {
            e.attack();
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        ThievesGuild thievesGuild = new ThievesGuild(10);
        Console.WriteLine("Thieves guild\n");
        thievesGuild.talk();
        thievesGuild.attack();

        FighterGuild fighterGuild = new FighterGuild(5);
        Console.WriteLine("\nFighter guild\n");
        fighterGuild.talk();
        fighterGuild.attack();


        Console.ReadKey();
    }
}
