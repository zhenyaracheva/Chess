namespace Chess.Players.Common
{
    using System.Collections.Generic;

    using Chess.Helpers;
    using Chess.Figures.Common;

    public interface IPlayer
    {
        string Name { get; set; }

        FigureColor Color { get; }

        State PlayerState { get; set; }

        IDictionary<Position, IFigure> Figures { get; }

        IList<IFigure> TakenFigures { get; }

        void TakeFigure(Position position,IFigure figure, IPlayer secondPlayer);

        void AddFigure(Position position, IFigure figure);

        void RemoveFigure(Position position);
    }
}
