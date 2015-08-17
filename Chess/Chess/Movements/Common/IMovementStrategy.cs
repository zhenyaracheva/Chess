namespace Chess.Movements.Common
{
    using System.Collections.Generic;

    using Chess.Helpers;
    using Chess.Figures.Common;

    public interface IMovementStrategy
    {
        ICollection<IMovement> Moves(FigureType figureType);
    }
}
