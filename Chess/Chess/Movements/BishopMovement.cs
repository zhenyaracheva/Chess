namespace Chess.Movements
{
    using System;

    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Movements.Common;

    public class BishopMovement : IMovement
    {
        private int rowDirection;
        private int colDirection;

        public void ValidateMove(IFigure figure, IBoard board, Helpers.Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            if (rowDistance != colDistance)
            {
                throw new InvalidOperationException("Invalid Bishop move!");
            }

            var otherColor = figure.Color == FigureColor.White ? FigureColor.Black : FigureColor.White;

            rowDirection = move.From.Row > move.To.Row ? -1 : 1;
            colDirection = move.From.Col > move.To.Col ? -1 : 1;

            var row = move.From.Row;
            var col = move.From.Col;

            var endRow = move.To.Row + rowDirection * (-1);
            var endCol = move.To.Col + colDirection * (-1);

            while (row != endRow && col != endCol)
            {
                row += rowDirection;
                col += colDirection;

                if (board.SeeFigureOnPosition(row, col) != null)
                {
                    throw new InvalidOperationException("Invalid Bishop move!");
                }
            }

            var toPositionFigure = board.SeeFigureOnPosition(move.To.Row, move.To.Col);

            if (toPositionFigure != null && toPositionFigure.Color == figure.Color)
            {
                throw new InvalidOperationException("Position is already taken!");
            }
        }
    }
}