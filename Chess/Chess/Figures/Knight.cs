namespace Chess.Figures
{
    using System.Collections.Generic;

    using Chess.Figures;
    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Movements.Common;

    public class Knight : Figure, IFigure
    {
        public Knight(FigureColor color)
            : base(color, FigureType.Knight)
        {
        }

       // public override ICollection<IMovement> Move(IMovementStrategy strategy)
       // {
       //     return strategy.Moves(this.Type);
       // }
    }
}