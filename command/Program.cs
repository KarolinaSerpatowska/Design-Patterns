using System;
using System.Collections.Generic;

public class Square
{
    float x;
    float y;

    public Square(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public void changeX(float val) { x += val; }
    public void changeY(float val) { y += val; }

    public void showPos()
    {
        Console.WriteLine("square pos: {0}, {1}", x, y);
    }
}

public interface IController
{
    void move(float x, float y);
    void undo();
}

public class SquareController:IController
{
    Square square;
    float changeX { get; set; }
    float changeY { get; set; }

    public SquareController(Square square)
    {
        this.square = square;
    }

    public void move(float x, float y)
    {
        square.changeX(x);
        square.changeY(y);
        changeX = x;
        changeY = y;
        square.showPos();
    }

    public void undo()
    {
        square.changeX(-changeX);
        square.changeY(-changeY);
        square.showPos();
    }
}

public class SquareChanger
{
    List<SquareController> controllers = new List<SquareController>();

    public void addSquare(Square square)
    {
        controllers.Add(new SquareController(square));
    }

    public void moveSquares(float x, float y)
    {
        foreach(var c in controllers)
        {
            c.move(x,y);
        }
    }

    public void undoAllMoves()
    {
        foreach(var c in controllers)
        {
            c.undo();
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        SquareChanger squareChanger = new SquareChanger();
        squareChanger.addSquare(new Square(10,10));
        squareChanger.addSquare(new Square(50,50));

        squareChanger.moveSquares(10,10);
        squareChanger.moveSquares(50, 50);

        squareChanger.undoAllMoves();
        squareChanger.undoAllMoves();


        Console.ReadKey();
    }
}
