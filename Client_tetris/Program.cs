using System.Data;
using Client_tetris.logic;
using Client_tetris.utills;

namespace Client_tetris;

internal static class Program
{
    public static string Username = "Anonim";
    public static bool isPlaying = true;

    private static void Main()
    {
        GameLogic.Init();

        Thread gameThread = new Thread(NextFrame);
        gameThread.Start();
        
        Thread inputThread = new Thread(Input.InputLoop);
        inputThread.Start();
    }

    private static void NextFrame()
    {
        while (isPlaying)
        {
            GameLogic.NextFrame();
            Output.ReDraw();
            Thread.Sleep(100);
        }
    }
}
