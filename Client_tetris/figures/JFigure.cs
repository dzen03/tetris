namespace Client_tetris.figures;

public class JFigure : Figure
{
    public (double x, double y)[] ToCoordinates()
    {
        return new (double x, double y)[] { (0, 0), 
                                            (0, 1), (1, 1), (2, 1) };
    }

    public (double x, double y)[] Rotate90Coordinates()
    {
        return new (double x, double y)[] { (0, 0), (1, 0), 
                                            (0, 1), 
                                            (0, 2)};
    }

    public (double x, double y)[] Rotate180Coordinates()
    {
        return new (double x, double y)[] { (0, 0), (1, 0), (2, 0), 
                                                            (2, 1) };
    }

    public (double x, double y)[] Rotate270Coordinates()
    {
        return new (double x, double y)[] { (1, 0), 
                                            (1, 1), 
                                    (0, 2), (1, 2) };
    }
}