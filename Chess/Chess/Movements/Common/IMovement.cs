namespace Chess.Movements.Common
{
    using Chess.Helpers;
    using Chess.Board.Common;
    using Chess.Figures.Common;

    public interface IMovement
    {
        void ValidateMove(IFigure figure, IBoard board, Move move);
    }
}
