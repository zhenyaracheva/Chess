namespace Chess.Figures
{
    using System.Collections.Generic;

    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Movements.Common;

    public class Rook : Figure, IFigure
    {
        public Rook(FigureColor color)
            : base(color, FigureType.Rook)
        {
        }
    }
}
