namespace Chess.Movements
{
    using System;

    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Movements.Common;
    using Chess.Helpers;

    public class KingMovement : IMovement
    {
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var figureToPosition = board.SeeFigureOnPosition(move.To.Row, move.To.Col);
            if (figureToPosition != null && figureToPosition.Color == figure.Color)
            {
                throw new InvalidOperationException("Position is already taken!");
            }

            if (!ValidKingMove(move))
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.ExceptionMessege, figure.Type));
            }
        }

        private bool ValidKingMove(Move move)
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
