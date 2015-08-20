namespace Chess.Figures
{
    using System;
    using System.Collections.Generic;

    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Movements.Common;

    public class Pawn : Figure, IFigure
    {
        public Pawn(FigureColor color)
            : base(color, FigureType.Pawn)
        {
        }
    }
}
