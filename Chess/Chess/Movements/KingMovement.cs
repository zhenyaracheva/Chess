namespace Chess.Movements
{
    using System;

    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Movements.Common;

    public class KingMovement : Movement, IMovement
    {
        public override void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            if (!ValidCastleMove(figure, board, move))
            {
                if (!this.ValidKingMove(figure, board, move))
                {
                    throw new InvalidOperationException(string.Format(GlobalConstants.ExceptionMessege, figure.Type));
                }
            }

            base.ValidateMove(figure, board, move);
        }

        private bool ValidCastleMove(IFigure figure, IBoard board, Move move)
        {
            var whiteLongCastle = CheckCaslte(figure, board, move, FigureColor.White, 7, 2, 1, 4);
            var whiteShortCastle = CheckCaslte(figure, board, move, FigureColor.White, 7, 6, 5, 6);
            var blackLongCastle = CheckCaslte(figure, board, move, FigureColor.Black, 0, 2, 1, 4);
            var blackShortCastle = CheckCaslte(figure, board, move, FigureColor.Black, 0, 6, 5, 6);

            return whiteShortCastle || whiteLongCastle ||
                   blackShortCastle || blackLongCastle;
        }

        private bool CheckCaslte(IFigure figure, IBoard board, Move move, FigureColor color, int row, int col, int startCheck, int endCheck)
        {
            if (figure.Color == color && move.To.Row == row && move.To.Col == col)
            {
                var rook = board.SeeFigureOnPosition(row, 0);

                if (rook.Color == color && rook.IsFirstMove && figure.IsFirstMove)
                {
                    for (int i = startCheck; i < endCheck; i++)
                    {
                        if (board.SeeFigureOnPosition(row, i) != null)
                        {
                            return false;
                        }

                    }

                    return true;
                }
            }

            return false;
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