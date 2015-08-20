namespace Chess.Figures
{
    using System.Collections.Generic;

    using Chess.Figures;
    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Movements.Common;

    public class Queen : Figure, IFigure
    {
        public Queen(FigureColor color)
            : base(color, FigureType.Queen)
        {
        }
    }
}
