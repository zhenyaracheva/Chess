namespace Chess.Movements.Common
{
    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Helpers;

    public interface IMovement
    {
        void ValidateMove(IFigure figure, IBoard board, Move move);
    }
}
