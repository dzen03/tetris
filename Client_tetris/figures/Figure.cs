namespace Client_tetris.figures;

public interface Figure
{
    public string? ToString();

    public (double x, double y)[] ToCoordinates();
    public (double x, double y)[] Rotate90Coordinates();
    public (double x, double y)[] Rotate180Coordinates();
    public (double x, double y)[] Rotate270Coordinates();

    public (double x, double y)[] RotateCoordinates(int rotations)
    {
        switch ((4000 + rotations) % 4)
        {
            case 0:
                return ToCoordinates();
            case 1:
                return Rotate90Coordinates();
            case 2:
                return Rotate180Coordinates();
            case 3:
                return Rotate270Coordinates();
            default:
                throw new NotSupportedException();
        }
    }
}