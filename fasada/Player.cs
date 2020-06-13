using System;
using System.Collections.Generic;

class Item
{
    string name;
    int cost;

    public Item(string s, int c)
    {
        name = s;
        cost = c;
    }

    public void printItem()
    {
        Console.WriteLine("Name: {0}, Cost: {1}",name,cost);
    }

    public string getName()
    {
        return name;
    }

    public int getCost()
    {
        return cost;
    }
}

class ShopInventory
{
    List<Item> items;
    int gold;

    public ShopInventory()
    {
        items = new List<Item>();
        gold = 1000;
        Item sword = new Item("Sword", 1000);
        Item book = new Item("Book", 50);
        Item fruit = new Item("Apple", 5);
        Item pickaxe = new Item("Pickaxe", 20);
        this.addItem(sword);
        this.addItem(book);
        this.addItem(fruit);
        this.addItem(pickaxe);
    }

    public void addItem(Item i)
    {
        items.Add(i);
        //Console.WriteLine("Added: ");
       // i.printItem();
    }

    public void removeItem(string name)
    {
        foreach (var item in items)
        {
            if (item.getName() == name)
            {
                items.Remove(item);
                break;
            }
        }
        Console.WriteLine("Removed Item from Shop: {0} ", name);
    }

    public void printItems()
    {
        Console.WriteLine("Shop Items: ");
        foreach (var item in items)
        {
            item.printItem();
        }
        Console.WriteLine("\n");
    }

    public int getGold()
    {
        return gold;
    }

    public void addGold(int money)
    {
        gold += money;
    }

    public void removeGold(int money)
    {
        gold -= money;
    }

    public Item searchItem(string name)
    {
        foreach (var item in items)
        {
            if (item.getName() == name) return item;
        }
        return null;
    }

}

class PlayerInventory
{
    int gold;
    List<Item> items;

    public PlayerInventory()
    {
        gold = 100;
        items = new List<Item>();
    }

    public void addItem(Item i)
    {
        items.Add(i);
        //Console.WriteLine("Added: ");
       // i.printItem();
    }

    public void removeItem(string name)
    {
        foreach(var item in items)
        {
            if (item.getName() == name)
            {
                items.Remove(item);
                break;
            }
        }
        Console.WriteLine("Removed Item from Player: {0} ", name);
    }

    public int getGold()
    {
        return gold;
    }

    public void addGold(int money)
    {
        gold += money;
    }

    public void removeGold(int money)
    {
        gold -= money;
    }

    public void printItems()
    {
        Console.WriteLine("Player Items: ");
        foreach (var item in items)
        {
            item.printItem();
        }
        Console.WriteLine("\n");
    }
}

class Seller
{
    public Seller() { }

    public bool accept()
    {
        Random rnd = new Random();
        int number=rnd.Next(1,3);
        if (number == 1) return true;
        else return false;
    }
}


class ShopManager
{
    PlayerInventory playerInventory = new PlayerInventory();
    ShopInventory shopInventory = new ShopInventory();
    Seller seller = new Seller();

    public ShopManager()
    {
        Console.WriteLine("Welcome in my shop \n");
        shopInventory.printItems();
    }

    public void buyItem(string name, int prize)
    {
        Item temp=shopInventory.searchItem(name);
        if (temp!=null && playerInventory.getGold() >= prize && prize==temp.getCost())
        {
            Item i = new Item(name, prize);
            playerInventory.addItem(i);
            playerInventory.removeGold(prize);
            shopInventory.removeItem(name);
        }
        else if(temp!=null && playerInventory.getGold() >= prize  && prize < temp.getCost() &&  seller.accept())
        {
            Console.WriteLine("Trade succesfull \n");
            Item i = new Item(name, prize);
            playerInventory.addItem(i);
            playerInventory.removeGold(prize);
            shopInventory.removeItem(name);
        }
        else
        {
            Console.WriteLine("Trade not succesfull \n");
        }
    }

    public void addItemToShop(Item i)
    {
        shopInventory.addItem(i);
    }

    public void showPlayerInventory()
    {
        Console.WriteLine("Player Inventory: ");
        playerInventory.printItems();
    }

    public void showShopInventory()
    {
        Console.WriteLine("Shop Inventory: ");
        shopInventory.printItems();
    }
    
}



class Player
{
   static void Main(string[] args)
   {
        ShopManager shopManager = new ShopManager();

        Console.WriteLine("Buy Book, price:50 ");
        shopManager.buyItem("Book", 50);
        shopManager.showPlayerInventory();
        shopManager.showShopInventory();
        Console.WriteLine("Buy Apple, price:2 ");
        shopManager.buyItem("Apple", 2);
        shopManager.showPlayerInventory();
        shopManager.showShopInventory();


        Console.ReadKey();
   }
}
