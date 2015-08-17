namespace Chess.Figures.Common
{
    using System.Collections.Generic;

    using Chess.Helpers;
    using Chess.Movements;
    using Chess.Movements.Common;

    public abstract class Figure : IFigure
    {
        public Figure(FigureColor color, FigureType type)
        {
            this.Color = color;
            this.Type = type;
        }

        public FigureColor Color { get; private set; }

        public FigureType Type { get; private set; }

        public abstract ICollection<IMovement> Move(IMovementStrategy strategy);
    }
}
