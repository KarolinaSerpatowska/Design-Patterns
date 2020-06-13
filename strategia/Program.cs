using System;
using System.Collections.Generic;

public interface IEntity
{
    void move();
    void attack();
    void changeWeapon(int id);
}

public class Enemy:IEntity
{
    IWeapon weapon;
    int weaponID;

    public Enemy(IWeapon weapon, int id)
    {
        this.weapon = weapon;
        weaponID = id;
    }

    public void move()
    {
        Console.WriteLine("Enemy move");
    }

    public void attack()
    {
        weapon.attack();
    }

    public void changeWeapon(int weaponID)
    {
        if(this.weaponID!= weaponID)
        {
            switch(weaponID)
            {
                case 0:
                    weapon = new Bow();
                    break;
                case 1:
                    weapon = new Sword();
                    break;
            }
            this.weaponID = weaponID;
            Console.WriteLine("change weapon");
        }
    }

}

public interface IWeapon
{
    void attack();
}

public class Bow:IWeapon
{
    public void attack()
    {
        Console.WriteLine("shot arrow");
    }
}

public class Sword : IWeapon
{
    public void attack()
    {
        Console.WriteLine("melee attack");
    }
}

public class Game
{
    List<IEntity> enemies;

    public Game(int number)
    {
        enemies = new List<IEntity>();
        for (int i = 0; i < number; i++)
        {
            enemies.Add(new Enemy(new Bow(), 0));
        }
    }

    public void changeEnenmyWeapon(int weaponID)
    {
       foreach(var e in enemies)
       {
            e.changeWeapon(weaponID);
       }
    }

    public void moveEnemies()
    {
        foreach(var e in enemies)
        {
            e.move();
        }
    }

    public void enemiesAttack()
    {
        foreach(var e in enemies)
        {
            e.attack();
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Game game = new Game(10);
        game.moveEnemies();
        game.enemiesAttack();
        game.changeEnenmyWeapon(1);
        game.enemiesAttack();


        Console.ReadKey();
    }
}
