namespace Chess.Figures
{
    using System.Collections.Generic;

    using Chess.Figures;
    using Chess.Helpers;
    using Chess.Figures.Common;
    using Chess.Movements.Common;

    public class King : Figure, IFigure
    {
        public King(FigureColor color)
            : base(color, FigureType.King)
        {
        }

        public override ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            throw new System.NotImplementedException();
        }
    }
}
