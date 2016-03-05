namespace Chess.Movements.Common
{
    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Helpers;

    public abstract class Movement : IMovement
    {
        public virtual void ValidateMove(IFigure figure, IBoard board, Move move)
        {
           if (figure.IsFirstMove)
           {
               figure.IsFirstMove = false;
           }
        }
    }
}
