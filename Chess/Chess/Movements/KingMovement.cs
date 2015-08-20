namespace Chess.Movements
{
    using System;

    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Movements.Common;

    public class KingMovement : Movement, IMovement
    {
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            if (!this.ValidKingMove(figure, board, move))
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.ExceptionMessege, figure.Type));
            }

            base.ValidateMove(figure, board, move);
        }

        private bool ValidKingMove(IFigure figure, IBoard board, Move move)
        {
            var startRow = move.From.Row;
            var startCol = move.From.Col;

            for (int row = startRow - 1; row <= startRow + 1; row++)
            {
                for (int col = startCol - 1; col <= startCol + 1; col++)
                {
                    if (move.To.Row == row && move.To.Col == col)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}