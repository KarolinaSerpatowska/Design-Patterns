using System;

class Order
{
    string name;
    string payment;
    float cost;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Payment
    {
        get { return payment; }
        set { payment = value; }
    }

    public float Cost
    {
        get { return cost; }
        set { cost = value; }
    }
    
    public OrderMemento saveMemento()
    {
        Console.WriteLine("Saving");
        return new OrderMemento(name, payment, cost);
    }

    public void restoreMemento(OrderMemento memento)
    {
        Name = memento.Name;
        Payment = memento.Payment;
        Cost = memento.Cost;
        Console.WriteLine("Restoring");
    }

    public void showOrder()
    {
        Console.WriteLine("Order: Name: {0}, Payment: {1}, Cost: {2}",Name, Payment, Cost);
    }
}

class OrderMemento
{
    string name { get; set; }
    string payment { get; set; }
    float cost { get; set; }

    public OrderMemento(string name, string payment, float cost)
    {
        this.name = name;
        this.payment = payment;
        this.cost = cost;
    }

    public string Name
    {
        get { return name; }
    }

    public string Payment
    {
        get { return payment; }
    }

    public float Cost
    {
        get { return cost; }
    }
}

class Memory
{
    OrderMemento memento;

    public OrderMemento Memento
    {
        set { memento = value; }
        get { return memento; }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Order order1 = new Order();
        order1.Name = "Book";
        order1.Payment = "card";
        order1.Cost = 50;
        order1.showOrder();
        Memory memory = new Memory();
        memory.Memento = order1.saveMemento();

        order1.Payment = "cash";
        order1.Cost = 60;
        order1.showOrder();
        order1.restoreMemento(memory.Memento);
        order1.showOrder();


        Console.ReadKey();
    }
}
