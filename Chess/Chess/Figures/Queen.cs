namespace Chess.Figures
{
    using System.Collections.Generic;

    using Chess.Figures;
    using Chess.Helpers;
    using Chess.Figures.Common;
    using Chess.Movements.Common;

    public class Queen : Figure, IFigure
    {
        public Queen(FigureColor color)
            : base(color, FigureType.Queen)
        {
        }

        public override ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            return strategy.Moves(this.Type);
        }
    }
}
