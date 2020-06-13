using System;
using System.Collections.Generic;

public interface IFlyweight
{
    void display();
}

public class Tree:IFlyweight
{
    int meshId;
    int textureId;

    public Tree()
    {
        textureId = 0;
        meshId = 1;
    }

    public void display()
    {
        Console.WriteLine("Tree mesh id: {0}, texture id: {1}", meshId, textureId);
    }
}

public class Ground : IFlyweight
{
    int meshId;
    int textureId;

    public Ground()
    {
        textureId = 10;
        meshId = 4;
    }

    public void display()
    {
        Console.WriteLine("Ground mesh id: {0}, texture id: {1}", meshId, textureId);
    }
}

public class ForestFlyweightFactory
{
    Dictionary<string, IFlyweight> meshes=new Dictionary<string, IFlyweight>();

    public IFlyweight provide(string key)
    {
        if (meshes.ContainsKey(key)) return meshes[key];
        else
        {
            IFlyweight flyweight = null;
            switch(key)
            {
                case "tree":
                    flyweight = new Tree();
                    break;
                case "ground":
                    flyweight = new Ground();
                    break;
            }
            meshes.Add(key, flyweight);
            return flyweight;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        ForestFlyweightFactory forestFlyweightFactory = new ForestFlyweightFactory();
        IFlyweight tree = forestFlyweightFactory.provide("tree");
        tree.display();
        IFlyweight ground = forestFlyweightFactory.provide("ground");
        ground.display();

        Console.ReadKey();
    }
}

