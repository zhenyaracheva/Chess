namespace Chess.Movements
{
    using System;

    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Movements.Common;

    public class BishopMovement : IMovement
    {
        public void ValidateMove(IFigure figure, IBoard board, Helpers.Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);


            if (rowDistance != colDistance)
            {
                throw new InvalidOperationException("Invalid Bishop move!");
            }

            // TODO: extract to method
            var other = figure.Color == FigureColor.White ? FigureColor.Black : FigureColor.White;
        }
    }
}
