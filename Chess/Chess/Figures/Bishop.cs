﻿namespace Chess.Figures
{
    using System.Collections.Generic;

    using Chess.Figures;
    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Movements.Common;

    public class Bishop : Figure, IFigure
    {
        public Bishop(FigureColor color)
            : base(color, FigureType.Bishop)
        {
        }
    }
}
