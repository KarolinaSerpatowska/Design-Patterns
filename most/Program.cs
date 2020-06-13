using System;

public interface IAmmunition
{
    void attackImplementation();
}

public class Normal:IAmmunition
{
    float dmg = 10;

    public void attackImplementation()
    {
        Console.WriteLine("Normal ammunition");
    }
}

public class Boom:IAmmunition
{
    float dmg = 50;

    public void attackImplementation()
    {
        Console.WriteLine("Ammunition with explosion");
    }
}

public abstract class RangeWeapon
{
    protected IAmmunition ammunition;

    public RangeWeapon(IAmmunition ammunition)
    {
        this.ammunition = ammunition;
    }

    public abstract void attack();
}

public class Bow:RangeWeapon
{
    public Bow(IAmmunition ammunition) : base(ammunition) { }

    public override void attack()
    {
        ammunition.attackImplementation();
    }
}

public class Gun:RangeWeapon
{
    public Gun(IAmmunition ammunition) : base(ammunition) { }

    public override void attack()
    {
        ammunition.attackImplementation();
    }
}



class Program
{
    static void Main(string[] args)
    {
        RangeWeapon bow = new Bow(new Normal());
        RangeWeapon gun = new Gun(new Boom());

        bow.attack();
        gun.attack();



        Console.ReadKey();
    }
}
