namespace Chess.Movements
{
    using System;

    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Movements.Common;

    public class RookMovement : IMovement
    {
        private int startPoint;
        private int endPoint;

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var figureToPosition = board.SeeFigureOnPosition(move.To.Row, move.To.Col);
            if (figureToPosition != null && figureToPosition.Color == figure.Color)
            {
                throw new ArgumentException("Position is already taken");
            }

            if (move.From.Row == move.To.Row)
            {
                SetStartEndPosition(move.From.Col, move.To.Col);
                ValidHorizontalMove(move.To.Row, board);
            }
            else if (move.From.Col == move.To.Col)
            {
                SetStartEndPosition(move.From.Row, move.To.Row);
                ValidVerticalMove(move.To.Col, board);
            }
            else
            {
                throw new ArgumentException("Invalid rook move!");
            }
        }

        private void SetStartEndPosition(int start, int end)
        {
            startPoint = start;
            endPoint = end;
            if (startPoint > endPoint)
            {
                startPoint = end;
                endPoint = start;
            }
        }

        private void ValidVerticalMove(int col, IBoard board)
        {
            for (int row = startPoint + 1; row < endPoint - 1; row++)
            {
                if (!ValidRookMove(row, col, board))
                {
                    throw new ArgumentException("Invalid rook move");
                }
            }
        }

        private void ValidHorizontalMove(int row, IBoard board)
        {
            for (int col = startPoint + 1; col < endPoint - 1; col++)
            {
                if (!ValidRookMove(row, col, board))
                {
                    throw new ArgumentException("Invalid rook move");
                }
            }
        }

        private bool ValidRookMove(int row, int col, IBoard board)
        {
            if (board.SeeFigureOnPosition(row, col) == null)
            {
                return true;
            }

            return false;
        }
    }
}
