using System.Data;
using Client_tetris.logic;

namespace Client_tetris.utills;

public static class Output
{
    public static void ReDraw()
    {
        Console.Clear();
        Console.WriteLine($"Welcome {Program.Username}\nNext figure:");

        var nextFig = GameLogic.NextFigure.ToString();
        Console.WriteLine(nextFig);
        
        Console.WriteLine($"Your score: {GameLogic.Score}");

        bool[,] dataCopy = new bool[GameLogic.Y, GameLogic.X];
        for (int i = 0; i < GameLogic.Y; ++i)
            for (int j = 0; j < GameLogic.X; ++j)
                dataCopy[i, j] = GameLogic.Data[i, j];


        foreach (var coord in GameLogic.FigurePosition)
        {
            dataCopy[(int)coord.y, (int)coord.x] = true;
        }

        for (int row = 0; row < GameLogic.Y; ++row)
        {
            Console.Write('|');
            for (int column = 0; column < GameLogic.X; ++column)
                Console.Write(dataCopy[row, column] ? '■' : ' ');
            Console.WriteLine('|');
        }
        
        foreach (var coord in GameLogic.FigurePosition)
        {
            dataCopy[(int)coord.y, (int)coord.x] = false;
        }
        Console.WriteLine();
    }
}