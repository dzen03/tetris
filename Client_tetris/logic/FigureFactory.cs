using Client_tetris.figures;

namespace Client_tetris.logic;

public class FigureFactory
{
    public static Figure Create(FigureType figureType)
    {
        switch (figureType)
        {
            case FigureType.I:
                return new IFigure();
            case FigureType.O:
                return new OFigure();
            case FigureType.J:
                return new JFigure();
            case FigureType.L:
                return new LFigure();
            case FigureType.S:
                return new SFigure();
            case FigureType.T:
                return new TFigure();
            case FigureType.Z:
                return new ZFigure();
            default:
                throw new NotSupportedException();
        }
    }
}