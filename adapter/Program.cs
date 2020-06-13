using System;

public interface IEnemy
{
    void meleeAttack();
    void specialAttack();
}

public class Enemy:IEnemy
{
    public void meleeAttack()
    {
        Console.WriteLine("Melee attack");
    }

    public void specialAttack()
    {
        Console.WriteLine("Special attack");
    }
}

public class WizardEnemy
{
    public void staffAttack()
    {
        Console.WriteLine("Staff attack");
    }

    public void magickAttack()
    {
        Console.WriteLine("Magick attack");
    }
}

public class WizardAdapter:IEnemy
{
    WizardEnemy wizard;

    public WizardAdapter(WizardEnemy wizard)
    {
        this.wizard = wizard;
    }

    public void meleeAttack()
    {
        wizard.staffAttack();
    }

    public void specialAttack()
    {
        wizard.magickAttack();
    }
}


class Program
{
    static void Main(string[] args)
    {
        WizardEnemy wizard = new WizardEnemy();
        IEnemy enemy = new WizardAdapter(wizard);

        enemy.meleeAttack();
        enemy.specialAttack();



        Console.ReadKey();
    }
}
