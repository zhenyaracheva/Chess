namespace Chess.Figures.Common
{
    using System;
    using System.Collections.Generic;

    using Chess.Helpers;
    using Chess.Movements.Common;

    public interface IFigure
    {
        FigureColor Color { get; }

        FigureType Type { get; }

        bool IsFirstMove { get; set; }

        ICollection<IMovement> Move(IMovementStrategy strategy);
    }
}
