using System;

public abstract class Enemy
{
    public abstract void attack();
    public abstract int getDmg();
}

public class Wolf:Enemy
{
    int hp;
    int dmg;

    public Wolf()
    {
        hp = 100;
        dmg = 10;
    }

    public override void attack()
    {
        Console.Write("Wolf: attack dmg: ");
    }

    public override int getDmg()
    {
        return dmg;
    }
}

public class Alien : Enemy
{
    int hp;
    int dmg;

    public Alien()
    {
        hp = 100;
        dmg = 50;
    }

    public override void attack()
    {
        Console.Write("Alien: attack dmg: ");
    }

    public override int getDmg()
    {
        return dmg;
    }
}

public class EnemyDecorator:Enemy
{
    protected Enemy enemy;
    protected int dmg;
    protected int hp;

    public EnemyDecorator(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public override void attack()
    {
        enemy.attack();
    }

    public override int getDmg()
    {
        return dmg;
    }
}

public class Boss:EnemyDecorator
{

    public Boss(Enemy enemy) : base(enemy)
    {
        hp = 200;
        this.dmg = enemy.getDmg() + 100;
    }

    public override void attack()
    {
        Console.Write("Boss ");
        base.attack();
        Console.Write("{0} \n", base.dmg + dmg);
    }

    public override int getDmg()
    {
        return dmg;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Enemy wolf = new Wolf();
        wolf = new Boss(wolf);
        wolf.attack();

        Enemy alien = new Alien();
        alien = new Boss(alien);
        alien.attack();


        Console.ReadKey();
    }
}
