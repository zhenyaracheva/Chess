namespace Chess.Movements
{
    using System;

    using Chess.Figures;
    using Chess.Helpers;
    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Movements.Common;

    public class PawnMovement : IMovement
    {
        private int whitePlayerStartRow;
        private int blackPlayerStartRow;
        private FigureColor oppositeColor;

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            whitePlayerStartRow = board.Size - 2;
            blackPlayerStartRow = 1;
            oppositeColor = figure.Color == FigureColor.White ? FigureColor.Black : FigureColor.White;


            if (figure.Color == FigureColor.White)
            {
                if (!ValidWhitePLayerMoves(move, board))
                {
                    throw new ArgumentException("White pawn cannot move that way!");
                }
            }
            else if (figure.Color == FigureColor.Black)
            {
                if (!ValidBlackPlayerMoves(move, board))
                {
                    throw new ArgumentException("Black pawn cannot move that way!");
                }
            }
        }

        private bool ValidBlackPlayerMoves(Move move, IBoard board)
        {
            var figureToPosition = board.SeeFigureOnPosition(move.To.Row, move.To.Col);

            if (figureToPosition == null)
            {


                return ValidCommonBlackPlayerMoves(move, figureToPosition, board);
            }
            else if (figureToPosition.Color == FigureColor.White)
            {
                if (move.From.Col - 1 == move.To.Col || move.From.Col + 1 == move.To.Col)
                {
                    return true;
                }
            }

            return false;
        }

        private bool ValidCommonBlackPlayerMoves(Move move, IFigure figure, IBoard board)
        {
            if (blackPlayerStartRow == move.From.Row &&
                move.From.Col == move.To.Col &&
                move.From.Row + 2 == move.To.Row &&
                board.SeeFigureOnPosition(move.From.Row + 1, move.From.Col) == null)
            {
                return true;
            }

            if (blackPlayerStartRow == move.From.Row &&
                    move.From.Col == move.To.Col &&
                    move.From.Row + 1 == move.To.Row)
            {
                return true;
            }

            if (move.From.Row + 1 == move.To.Row && move.From.Col == move.To.Col && figure == null)
            {
                return true;
            }

            return false;
        }

        private bool ValidWhitePLayerMoves(Move move, IBoard board)
        {
            var figureToPosition = board.SeeFigureOnPosition(move.To.Row, move.To.Col);

            if (figureToPosition == null)
            {
                return ValidCommonWhitePlayerMoves(move, figureToPosition, board);
            }
            else if (figureToPosition.Color == FigureColor.Black)
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
            if (whitePlayerStartRow == move.From.Row &&
                  move.From.Col == move.To.Col &&
                  move.From.Row - 2 == move.To.Row &&
                  board.SeeFigureOnPosition(move.From.Row - 1, move.From.Col) == null)
            {
                return true;
            }

            if (whitePlayerStartRow == move.From.Row &&
                    move.From.Col == move.To.Col &&
                    move.From.Row - 1 == move.To.Row)
            {
                return true;
            }

            if (move.From.Row - 1 == move.To.Row && move.From.Col == move.To.Col && figure == null)
            {
                return true;
            }

            return false;
        }
    }
}