using System;

public interface IState
{
    void Enter();
    void Execute();
    void Exit();
}

public class StateAttack : IState
{
    Player owner;

    public StateAttack(Player owner) { this.owner = owner; }

    public void Enter()
    {
        Console.WriteLine("entering attack state");
    }

    public void Execute()
    {
        Console.WriteLine("updating attack state");
    }

    public void Exit()
    {
        Console.WriteLine("exiting attack state");
    }

}

public class StateMove : IState
{
    private Player owner;

    public StateMove(Player owner) { this.owner = owner; }


    public void Enter()
    {
        Console.WriteLine("entering move state");
    }

    public void Execute()
    {
        Console.WriteLine("updating move state");

    }

    public void Exit()
    {

        Console.WriteLine("exiting move state");
    }
}

public class StateStay : IState
{
    Player owner;

    public StateStay(Player owner)
    {
        this.owner = owner;
    }

    public void Enter()
    {
        Console.WriteLine("entering stay state");
    }

    public void Execute()
    {
        Console.WriteLine("updating stay state");   
    }

    public void Exit()
    {
        Console.WriteLine("exiting stay state");
    }
}


public class StateMachine
{
    IState currState;

    public void ChangeState(IState newState)
    {
        if (currState != null)
            currState.Exit();

        currState = newState;
        currState.Enter();
    }

    public void Update()
    {
        if (currState != null) currState.Execute();
    }
}

public class Player
{
    StateMachine stateMachine = new StateMachine();

    public Player()
    {
        stateMachine.ChangeState(new StateStay(this));
    }

    public void updateState(IState state)
    {
        stateMachine.ChangeState(state);
        stateMachine.Update();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        player.updateState(new StateAttack(player));
        player.updateState(new StateMove(player));


        Console.ReadKey();
    }
}
