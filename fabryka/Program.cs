using System;
using System.Collections.Generic;

public interface NPC
{
    void doSomething();
}

public interface NpcGenerator
{
    NPC createNpc();
}

public class Soldier:NPC
{
    public Soldier() { }
    public void doSomething()
    {
        Console.WriteLine("Soldier: go on patrol");
    }
}

public class Bandit:NPC
{
    public Bandit() { }
    public void doSomething()
    {
        Console.WriteLine("Bandit: attack");
    }
}

public class SoldierGen:NpcGenerator
{
    public SoldierGen() { }

    public NPC createNpc()
    {
        return new Soldier();
    }
}

public class BanditGen : NpcGenerator
{
    public BanditGen() { }

    public NPC createNpc()
    {
        return new Bandit();
    }
}

public class Camp
{
    List<NPC> npcs;
    SoldierGen soldierGen;
    BanditGen banditGen;

    public Camp(int number)
    {
        soldierGen = new SoldierGen();
        banditGen = new BanditGen();
        npcs = new List<NPC>();

        for (int i = 0; i < number; i++)
        {
            npcs.Add(soldierGen.createNpc());
            if (i<5) npcs.Add(banditGen.createNpc());
        }
    }

    public void doSomething()
    {
        foreach (var s in npcs)
        {
            s.doSomething();
        }
    }
}



class Program
{
    static void Main(string[] args)
    {
        Camp camp = new Camp(10);
        camp.doSomething();


        Console.ReadKey();
    }
}
