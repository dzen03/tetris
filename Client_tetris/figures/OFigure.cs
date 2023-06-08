namespace Client_tetris.figures;

public class OFigure : Figure
{
    public (double x, double y)[] ToCoordinates()
    {
        return new (double x, double y)[] { (0, 0), (1, 0), 
                                            (0, 1), (1, 1) };
    }

    public (double x, double y)[] Rotate90Coordinates()
    {
        return ToCoordinates();
    }

    public (double x, double y)[] Rotate180Coordinates()
    {
        return ToCoordinates();
    }

    public (double x, double y)[] Rotate270Coordinates()
    {
        return ToCoordinates();
    }
}