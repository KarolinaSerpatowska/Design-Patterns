using System;
using System.Collections.Generic;

public class BuilderDirector
{
    public void createLevel(Builder builder)
    {
        builder.buildEnvironment();
        builder.buildNPC();
        builder.buildEnemy();
    }
}

public abstract class Builder
{
    public abstract void buildEnvironment();
    public abstract void buildEnemy();
    public abstract void buildNPC();
    public abstract void showLevel();
}

public class TutorialLevel:Builder
{
    Level level=new Level();

    public override void buildEnvironment()
    {
        Console.WriteLine("Building environment");
        level.setEnviroment();
    }

    public override void buildEnemy()
    {
        Console.WriteLine("Building enemy");
    }

    public override void buildNPC()
    {
        Console.WriteLine("Building npc ");
        level.addNPC("Janusz");
    }

    public override void showLevel()
    {
        level.showLevel();
    }
}

public class Level
{
    EnvironmentThings environment;
    List<NPC> npcs = new List<NPC>();

    public void addNPC(string name)
    {
        NPC n= new NPC(name);
        npcs.Add(n);
    }

    public void setEnviroment()
    {
        EnvironmentThings e=new EnvironmentThings();
        for (int i = 0; i < 10; i++)
        {
            e.addObj(i);
        }
        environment = e;
    }

    public void showLevel()
    {
        foreach(var n in npcs)
        {
            Console.WriteLine("NPC: {0}", n.getName());
        }
        Console.WriteLine("level elements:");
        environment.showList();
    }

}

public class NPC
{
    string name;
    
    public NPC(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }
}

public class EnvironmentThings
{
    List<int> id=new List<int>();

    public void addObj(int v)
    {
        id.Add(v);
    }

    public void showList()
    {
        foreach(var e in id)
        {
            Console.WriteLine(e);
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        BuilderDirector builderDirector = new BuilderDirector();
        Builder levelBuilder = new TutorialLevel();
        builderDirector.createLevel(levelBuilder);

        levelBuilder.showLevel();
        


        Console.ReadKey();
    }
}
