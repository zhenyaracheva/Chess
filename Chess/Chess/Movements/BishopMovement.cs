namespace Chess.Movements
{
    using System;

    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Movements.Common;
    using Chess.Helpers;

    public class BishopMovement : Movement, IMovement
    {
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            if (rowDistance != colDistance)
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.ExceptionMessege, figure.Type));
            }

            int rowDirection = move.From.Row > move.To.Row ? -1 : 1;
            int colDirection = move.From.Col > move.To.Col ? -1 : 1;

            var row = move.From.Row;
            var col = move.From.Col;

            var endRow = move.To.Row + rowDirection * (-1);
            var endCol = move.To.Col + colDirection * (-1);

            while (row != endRow && col != endCol)
            {
                row += rowDirection;
                col += colDirection;

                if ( board.SeeFigureOnPosition(row, col) != null)
                {
                    throw new InvalidOperationException(string.Format(GlobalConstants.ExceptionMessege, figure.Type));
                }
            }

            base.ValidateMove(figure, board, move);
        }
    }
}