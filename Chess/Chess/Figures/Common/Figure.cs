namespace Chess.Figures.Common
{
    using System.Collections.Generic;
    
    using Chess.Movements.Common;

    public abstract class Figure : IFigure
    {
        public Figure(FigureColor color, FigureType type)
        {
            this.Color = color;
            this.Type = type;
            this.IsFirstMove = true;
        }

        public FigureColor Color { get; private set; }

        public FigureType Type { get; private set; }

        public bool IsFirstMove { get; set; }

        public ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            return strategy.Moves(this.Type);
        }
    }
}
