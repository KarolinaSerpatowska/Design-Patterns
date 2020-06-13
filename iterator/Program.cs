using System;
using System.Collections.Generic;

public abstract class Iterator
{
    public abstract object first();
    public abstract object next();
    public abstract bool hasNext();
    public abstract object current();
    public abstract bool isLast();
    public abstract object last();
}

public class MyIterator : Iterator
{
    List<Object> list;
    int pos = 0;

    public MyIterator(List<Object> l)
    {
        list = l;
    }

    public override object first()
    {
        return list[0];
    }

    public override object next()
    {
        if (pos < list.Count - 1) return list[++pos];
        else return null;
    }

    public override bool hasNext()
    {
        if (pos < list.Count - 1) return true;
        else return false;
    }

    public override object current()
    {
        return list[pos];
    }

    public override bool isLast()
    {
        if (pos == list.Count - 1) return true;
        else return false;
    }

    public override object last()
    {
        return list[list.Count - 1];
    }
}


class Program
{
    static void Main(string[] args)
    {
        List<Object> list = new List<Object>();
        for(int i=0;i<10;i++)
        {
            list.Add(i);
        }
        list.Add("napis");

        MyIterator it = new MyIterator(list);

        Console.WriteLine("has next elem: {0}", it.hasNext());
        Console.WriteLine("is last elem: {0}", it.isLast());
        Console.WriteLine("curr elem: {0}", it.current());
        Console.WriteLine("last elem: {0}", it.last());
        Console.WriteLine("first elem: {0}", it.first());
        Console.WriteLine("next elem: ");
        Console.WriteLine(it.next());
        Console.WriteLine(it.next());
        Console.WriteLine(it.next());
        Console.WriteLine(it.next());
        while(!it.isLast())
        {
            Console.WriteLine(it.next());
        }

        Console.ReadKey();
    }
}
