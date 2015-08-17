namespace Chess.Figures
{
    using System;
    using System.Collections.Generic;

    using Chess.Helpers;
    using Chess.Figures.Common;
    using Chess.Movements.Common;

    public class Pawn : Figure, IFigure
    {
        public Pawn(FigureColor color)
            : base(color, FigureType.Pawn)
        {
            this.IsFirstMove = true;
            this.Direction = color == FigureColor.White ? Direction.Up : Direction.Down;
        }

        public bool IsFirstMove { get; set; }

        public Direction Direction { get; set; }

        public override ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            return strategy.Moves(this.Type);
        }
    }
}
