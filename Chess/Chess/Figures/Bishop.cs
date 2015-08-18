namespace Chess.Figures
{
    using System.Collections.Generic;

    using Chess.Figures;
    using Chess.Helpers;
    using Chess.Figures.Common;
    using Chess.Movements.Common;

    public class Bishop : Figure, IFigure
    {
        public Bishop(FigureColor color)
            : base(color, FigureType.Bishop)
        {
        }

        public override ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            return strategy.Moves(this.Type);
        }
    }
}
