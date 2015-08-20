namespace Chess.Movements
{
    using System;
    using System.Collections.Generic;

    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Movements.Common;

    public class KnightMovement : Movement, IMovement
    {
        private readonly List<int[]> directions = new List<int[]>()
                                                                   {
                                                                    new int[] { 1, 2 },
                                                                    new int[] { 2, 1 },
                                                                    new int[] { 1, -2 },
                                                                    new int[] { 2, -1 },
                                                                   };

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var otherColor = figure.Color == FigureColor.White ? FigureColor.Black : FigureColor.White;

            if (!this.ValidMove(move))
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.ExceptionMessege, figure.Type));
            }

            base.ValidateMove(figure, board, move);
        }

        private bool ValidMove(Move move)
        {
            var counter = 0;
            for (int i = 0; i < this.directions.Count; i++)
            {
                var directionRow = this.directions[i][0];
                var directionCol = this.directions[i][1];

                if (!this.CheckValidStep(move, directionRow, directionCol) && !this.CheckValidStep(move, directionRow * (-1), directionCol * (-1)))
                {
                    counter++;
                }
            }

            if (counter == this.directions.Count)
            {
                return false;
            }

            return true;
        }

        private bool CheckValidStep(Move move, int directionRow, int directionCol)
        {
            if (move.To.Row == move.From.Row + directionRow && move.To.Col == move.From.Col + directionCol)
            {
                return true;
            }

            return false;
        }
    }
}