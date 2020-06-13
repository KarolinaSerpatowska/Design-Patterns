using System;
using System.Collections.Generic;

public interface IEntity
{
    void move();
    void attack();
    void changeWeapon(Weapon weapon);
}

public class Enemy : IEntity
{
    Weapon weapon;

    public Enemy(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public void move()
    {
        Console.WriteLine("Enemy move");
    }

    public void attack()
    {
        weapon.attack();
    }

    public void changeWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        Console.WriteLine("change weapon");
    }

}

public abstract class Weapon
{
    public abstract void playAnimation();
    public abstract void checkCollision();

    void startAttack()
    {
        Console.WriteLine("Start attack");
        Console.WriteLine("Create hitbox");
    }

    void calculateDmg()
    {
        Console.WriteLine("Calculate dmg");
    }

    public void attack()
    {
        startAttack();
        playAnimation();
        checkCollision();
        calculateDmg();
    }
}

public class Bow : Weapon
{
    public override void playAnimation()
    {
        Console.WriteLine("Play bow animation");
    }

    public override void checkCollision()
    {
        Console.WriteLine("Check arrow collision");
    }
}

public class Sword : Weapon
{
    public override void playAnimation()
    {
        Console.WriteLine("Play sword attack animation");
    }

    public override void checkCollision()
    {
        Console.WriteLine("Check sword collision");
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
            enemies.Add(new Enemy(new Bow()));
        }
    }

    public void changeEnenmyWeapon()
    {
        foreach (var e in enemies)
        {
            e.changeWeapon(new Sword());
        }
    }

    public void moveEnemies()
    {
        foreach (var e in enemies)
        {
            e.move();
        }
    }

    public void enemiesAttack()
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
        Game game = new Game(10);
        game.moveEnemies();
        game.enemiesAttack();
        game.changeEnenmyWeapon();
        game.enemiesAttack();


        Console.ReadKey();

    }
}

