using System.Data;
using System.Numerics;
using System.Security;
using Client_tetris.figures;

namespace Client_tetris.logic;

public class GameLogic
{
    public static Figure NextFigure;
    public static Figure CurrentFigure;
    public static bool IsDown = true;

    public const int X = 10;
    public const int Y = 40;

    public static MoveType NextMoveType = MoveType.Down;
    public static CheatType? CheatType = null;
    

    private static (double x, double y)[] _figurePosition;
    private static bool[,] _data = new bool[Y, X];

    private static double _velocity = 5;
    
    private static DateTime _prevDateTime = DateTime.Now;

    private static int _rotations = 0;

    public static int Score = 0;
    public static int Level = 1;
    

    public static (double x, double y)[] FigurePosition
    {
        get => _figurePosition;
    }

    public static bool[,] Data
    {
        get => _data;
    }

    public static void Init()
    {
        NextFigure = FigureFactory.Create(GetNext());
    }

    public static void NextFrame()
    {
        bool isEnd = false;
        for (int column = 0; column < X; ++column)
            isEnd |= _data[0, column];

        if (isEnd)
        {
            Program.isPlaying = false;
            return;
        }

        if (IsDown)
        {
            int rowsCleared = 0;
            for (int row = Y - 1; row >= 0; --row) // Check for full row to remove & add points
            {
                bool full = true;
                for (int column = 0; column < X; ++column)
                    if (!_data[row, column])
                    {
                        full = false;
                        break;
                    }

                if (full)
                {
                    _velocity *= 1.15;
                    ++rowsCleared;
                    
                    for (int newRow = row; newRow > 0; --newRow)
                    {
                        for (int column = 0; column < X; ++column)
                            _data[newRow, column] = _data[newRow - 1, column];
                    }

                    for (int column = 0; column < X; ++column)
                        _data[0, column] = false;

                    ++row;
                }
            }

            switch (rowsCleared)
            {
                case 0:
                    break;
                case 1:
                    Score += 100 * Level;
                    break;
                case 2:
                    Score += 300 * Level;
                    break;
                case 3:
                    Score += 500 * Level;
                    break;
                case 4:
                    Score += 800 * Level;
                    break;
                default:
                    throw new SecurityException("How do you managed to clear more than 4 rows???");
            }
            
            CurrentFigure = NextFigure;
            _figurePosition = CurrentFigure.ToCoordinates();
            NextFigure = FigureFactory.Create(GetNext());
            _rotations = 0;
            IsDown = false;
        }
        
        DoMove();
        _prevDateTime = DateTime.Now;
    }

    public static void DropFigure()
    {
        CheckBoundaries(0, 1);
        while (!IsDown)
        {
            Move(0, 1);
            CheckBoundaries(0, 1);
        }
    }

    public static (double dx, double dy) CheckBoundaries(double dx, double dy)
    {
        for(int i = 0; i < _figurePosition.Length; ++i)
        {
            
            if (_figurePosition[i].y + dy >= Y || _data[(int)(_figurePosition[i].y + dy), (int)(_figurePosition[i].x)])
            {
                IsDown = true;
                dy = 0;
            }

            if (!IsDown && (_figurePosition[i].x + dx < 0 || _figurePosition[i].x + dx >= X || 
                            _data[(int)(_figurePosition[i].y + dy), (int)(_figurePosition[i].x + dx)]))
                dx = 0;
        }

        return (dx, dy);
    }

    public static void Move(double dx, double dy)
    {
        for(int i = 0; i < _figurePosition.Length; ++i)
        {
            _figurePosition[i].x += dx;
            _figurePosition[i].y += dy;
        }
    }

    public static void DoMove()
    {
        switch (CheatType)
        {
            case null:
                break;
            case logic.CheatType.IncreaseVelocity:
                _velocity += 1;
                break;
            case logic.CheatType.DecreaseVelocity:
                _velocity -= 1;
                break;
        }

        double dx = 0, dy = 1;
        dy *= _velocity * ((DateTime.Now - _prevDateTime).TotalMilliseconds / 1000);
        if (NextMoveType == MoveType.Drop)
        {
            DropFigure();
            dx = dy = 0;
        }
        else if (NextMoveType == MoveType.Left)
            dx = -1;
        else if (NextMoveType == MoveType.Right)
            dx = 1;
        else if (NextMoveType == MoveType.Rotate)
        {
            double minX = double.MaxValue, minY = Double.MaxValue;
            foreach (var coord in _figurePosition)
            {
                minX = Math.Min(minX, coord.x);
                minY = Math.Min(minY, coord.y);
            }

            var tmp =  CurrentFigure.RotateCoordinates(++_rotations);
            for (int i = 0; i < _figurePosition.Length; ++i)
            {
                tmp[i].x += minX;
                tmp[i].y += minY;
            }

            bool canRotate = true;
            foreach (var coord in tmp)
            {
                if (coord.x >= X || coord.x < 0 || coord.y < 0 || coord.y >= Y ||
                    _data[(int)(coord.y), (int)(coord.x)])
                    canRotate = false;
            }

            if (canRotate)
                _figurePosition = tmp;
        }
        
        (dx, dy) = CheckBoundaries(dx, dy);

        if (!IsDown)
        {
            Move(dx, dy);
        }
        else
        {
            IsDown = false;
            DropFigure();
            foreach (var coord in _figurePosition)
            {
                _data[(int)coord.y, (int)coord.x] = true;
            }
        }
        
        NextMoveType = MoveType.Down;
    }

    public static FigureType GetNext()
    {
        Random random = new Random();
        Array values = typeof(FigureType).GetEnumValues();
        int index = random.Next(values.Length);
        return (FigureType)values.GetValue(index);
    }
}