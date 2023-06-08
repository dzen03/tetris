namespace Client_tetris.figures;

public class IFigure : Figure
{
    public (double x, double y)[] ToCoordinates()
    {
        return new (double x, double y)[] { (0, 0), (1, 0), (2, 0), (3, 0) };
    }

    public (double x, double y)[] Rotate90Coordinates()
    {
        return new (double x, double y)[] { (0, 0), (0, 1), (0, 2), (0, 3) };
    }

    public (double x, double y)[] Rotate180Coordinates()
    {
        return ToCoordinates();
    }

    public (double x, double y)[] Rotate270Coordinates()
    {
        return Rotate90Coordinates();
    }
}