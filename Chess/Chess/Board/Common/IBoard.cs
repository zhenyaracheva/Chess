namespace Chess.Board.Common
{
    using Chess.Figures.Common;

    public interface IBoard
    {
        int Size { get; }

        int Row { get; set; }

        int Col { get; set; }

        IFigure SeeFigureOnPosition(int row, int col);

        void SetFigure(int row, int col, IFigure figure);

        IFigure GetFigure(int row, int col);

        void InitializeStartGameBoard();
    }
}
