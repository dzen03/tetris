using Client_tetris.logic;

namespace Client_tetris.utills;

public static class Input
{
    public static void InputLoop()
    {
        while (Program.isPlaying)
        {
            ConsoleKey consoleKey = ConsoleKey.F24;
            if (Console.KeyAvailable)
                consoleKey = Console.ReadKey().Key;

            switch (consoleKey)
            {
                case ConsoleKey.LeftArrow:
                    GameLogic.NextMoveType = MoveType.Left;
                    break;
                case ConsoleKey.RightArrow:
                    GameLogic.NextMoveType = MoveType.Right;
                    break;
                case ConsoleKey.Q:
                    Program.isPlaying = false;
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.Spacebar:
                    GameLogic.NextMoveType = MoveType.Rotate;
                    break;
                case ConsoleKey.DownArrow:
                    GameLogic.NextMoveType = MoveType.Drop;
                    break;
                
                
                
                case ConsoleKey.P:
                    GameLogic.CheatType = CheatType.IncreaseVelocity;
                    break;
                case ConsoleKey.O:
                    GameLogic.CheatType = CheatType.DecreaseVelocity;
                    break;
            }
        }
    }
}