using System;
using System.Collections.Generic;

public interface Item
{
    void add(Item i);
    void remove(Item i);
    void show();
}

public class Weapon : Item
{
    public Weapon() { }

    public void add(Item i)
    {
        Console.WriteLine("No");
    }

    public void remove(Item i)
    {
        Console.WriteLine("No");
    }

    public void show()
    {
        Console.WriteLine("This is weapon");
    }
}

public class Food : Item
{
    public Food() { }

    public void add(Item i)
    {
        Console.WriteLine("No");
    }

    public void remove(Item i)
    {
        Console.WriteLine("No");
    }

    public void show()
    {
        Console.WriteLine("This is food");
    }
}

public class Equipment:Item
{
    List<Item> items;

    public Equipment()
    {
        items = new List<Item>();
    }

    public void add(Item i)
    {
        items.Add(i);
    }

    public void remove(Item i)
    {
        items.Remove(i);
    }

    public void show()
    {
        foreach(var i in items)
        {
            i.show();
        }
    }
}



class Program
{
     static void Main(string[] args)
    {
        Equipment equipment = new Equipment();
        equipment.add(new Weapon());
        equipment.add(new Food());
        equipment.show();


        Console.ReadKey();
    }
}
