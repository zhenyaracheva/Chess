namespace Chess.Movements
{
    using System;

    using Chess.Board.Common;
    using Chess.Figures;
    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Movements.Common;

    public class PawnMovement : Movement, IMovement
    {
        private FigureColor oppositeColor;
        private int startRow;
        private int direction;

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            this.startRow = figure.Color == FigureColor.White ? board.Size - 2 : 1;
            this.oppositeColor = figure.Color == FigureColor.White ? FigureColor.Black : FigureColor.White;
            this.direction = (figure.Color == FigureColor.White) ? -1 : 1;

            if (!this.ValidPLayerMoves(move, board))
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.ExceptionMessege, figure.Type));
            }

            base.ValidateMove(figure, board, move);
        }

        private bool ValidPLayerMoves(Move move, IBoard board)
        {
            var figureToPosition = board.SeeFigureOnPosition(move.To.Row, move.To.Col);

            if (figureToPosition == null)
            {
                return this.ValidEmptyCellMoves(move, figureToPosition, board);
            }
            else if (figureToPosition.Color == this.oppositeColor)
            {
                if (move.From.Row + this.direction == move.To.Row && (move.From.Col - 1 == move.To.Col || move.From.Col + 1 == move.To.Col))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ValidEmptyCellMoves(Move move, IFigure figure, IBoard board)
        {
            if (this.startRow == move.From.Row &&
                  move.From.Col == move.To.Col &&
                  move.From.Row + (2 * this.direction) == move.To.Row &&
                  board.SeeFigureOnPosition(move.From.Row + this.direction, move.From.Col) == null)
            {
                return true;
            }

            if (this.startRow == move.From.Row &&
                    move.From.Col == move.To.Col &&
                    move.From.Row + this.direction == move.To.Row)
            {
                return true;
            }

            if (move.From.Row + this.direction == move.To.Row && move.From.Col == move.To.Col && figure == null)
            {
                return true;
            }

            return false;
        }
    }
}