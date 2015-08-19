﻿namespace Chess.Movements
{
    using System;

    using Chess.Figures;
    using Chess.Helpers;
    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Movements.Common;

    public class PawnMovement : IMovement
    {
        private FigureColor oppositeColor;
        private int startRow;
        private int direction;

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            startRow = figure.Color == FigureColor.White ? board.Size - 2 : 1;
            oppositeColor = figure.Color == FigureColor.White ? FigureColor.Black : FigureColor.White;
            direction = (figure.Color == FigureColor.White) ? -1 : 1;

            if (!ValidWhitePLayerMoves(move, board))
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.ExceptionMessege, figure.Type));
            }
        }

        private bool ValidWhitePLayerMoves(Move move, IBoard board)
        {
            var figureToPosition = board.SeeFigureOnPosition(move.To.Row, move.To.Col);

            if (figureToPosition == null)
            {
                return ValidCommonWhitePlayerMoves(move, figureToPosition, board);
            }
            else if (figureToPosition.Color == oppositeColor)
            {
                if (move.From.Col - 1 == move.To.Col || move.From.Col + 1 == move.To.Col)
                {
                    return true;
                }
            }

            return false;
        }

        private bool ValidCommonWhitePlayerMoves(Move move, IFigure figure, IBoard board)
        {

            if (startRow == move.From.Row &&
                  move.From.Col == move.To.Col &&
                  move.From.Row + (2 * direction) == move.To.Row &&
                  board.SeeFigureOnPosition(move.From.Row + direction, move.From.Col) == null)
            {
                return true;
            }

            if (startRow == move.From.Row &&
                    move.From.Col == move.To.Col &&
                    move.From.Row + direction == move.To.Row)
            {
                return true;
            }

            if (move.From.Row + direction == move.To.Row && move.From.Col == move.To.Col && figure == null)
            {
                return true;
            }

            return false;
        }
    }
}