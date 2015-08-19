namespace Chess.Movements.Common
{
    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Helpers;

    public class Movement : IMovement
    {
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
           if (figure.IsFirstMove)
           {
               figure.IsFirstMove = false;
           }
        }
    }
}
