namespace Chess.Movements
{
    using System;

    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Movements.Common;

    public class RookMovement : IMovement
    {
        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            if (rowDistance > 0 && colDistance > 0)
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.ExceptionMessege, figure.Type));
            }

            var rowDirection = move.From.Row < move.To.Row ? 1 : -1;
            var colDirection = move.From.Col < move.To.Col ? 1 : -1;

            rowDirection = rowDistance > 0 ? rowDirection : 0;
            colDirection = colDistance > 0 ? colDirection : 0;

            var row = move.From.Row;
            var col = move.From.Col;

            while (true)
            {
                row += rowDirection;
                col += colDirection;

                if (board.SeeFigureOnPosition(row, col) != null)
                {
                    throw new InvalidOperationException(string.Format(GlobalConstants.ExceptionMessege, figure.Type));
                }

                if (row == move.To.Row && col == move.To.Col)
                {
                    break;
                }
            }
        }
    }
}
