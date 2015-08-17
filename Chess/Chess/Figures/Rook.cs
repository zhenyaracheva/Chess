namespace Chess.Figures
{
    using System.Collections.Generic;

    using Chess.Helpers;
    using Chess.Figures.Common;
    using Chess.Movements.Common;

    public class Rook : Figure, IFigure
    {
        public Rook(FigureColor color)
            : base(color, FigureType.Rook)
        {
        }

        public override System.Collections.Generic.ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            throw new System.NotImplementedException();
        }
    }
}
