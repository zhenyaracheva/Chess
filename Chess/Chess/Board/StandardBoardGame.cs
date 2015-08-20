namespace Chess.Board
{
    using System;

    using Chess.Board.Common;
    using Chess.Figures;
    using Chess.Figures.Common;
    using Chess.Helpers;

    public class StandardBoardGame : Board, IBoard
    {
        public StandardBoardGame()
            : base(GlobalConstants.StandatdBoardGameSize)
        {
        }

        public override void InitializeStartGameBoard()
        {
            var figureIndex = 0;
            var firstPlayerRow = GlobalConstants.StandatdBoardGameSize - GlobalConstants.InitialRowsWithFigures + 1;

            for (int secondPlayerRow = 0; secondPlayerRow < GlobalConstants.InitialRowsWithFigures; secondPlayerRow++)
            {
                for (int col = 0; col < GlobalConstants.StandatdBoardGameSize; col++)
                {
                    var currentFigureType = GlobalConstants.StartFigureOrderStandartGame[figureIndex];
                    this.SetFigure(firstPlayerRow, col, (IFigure)Activator.CreateInstance(currentFigureType, FigureColor.White));
                    this.SetFigure(secondPlayerRow, col, (IFigure)Activator.CreateInstance(currentFigureType, FigureColor.Black));
                    figureIndex++;
                }

                firstPlayerRow--;
            }
        }
    }
}