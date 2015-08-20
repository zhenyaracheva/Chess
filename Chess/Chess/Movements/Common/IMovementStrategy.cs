namespace Chess.Movements.Common
{
    using System.Collections.Generic;

    using Chess.Figures.Common;
    using Chess.Helpers;

    public interface IMovementStrategy
    {
        ICollection<IMovement> Moves(FigureType figureType);
    }
}
