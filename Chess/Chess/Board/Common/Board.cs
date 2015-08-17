namespace Chess.Board.Common
{
    using System;

    using Chess.Figures;
    using Chess.Helpers;
    using Chess.Figures.Common;

    public abstract class Board : IBoard
    {
        private IFigure[,] board;
        private int row;
        private int col;

        public Board(int size)
        {
            this.Size = size;
            this.board = new Figure[this.Size, this.Size];
            this.InitializeStartGameBoard();
        }

        public int Size { get; private set; }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                Validator.ValidRange(value, 0, this.board.GetLength(0) - 1, "Board row must be between 0 and " + this.board.GetLength(0));

                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                Validator.ValidRange(value, 0, this.board.GetLength(1) - 1, "Board col must be between 0 and " + this.board.GetLength(1));

                this.col = value;
            }
        }


        public IFigure SeeFigureOnPosition(int row, int col)
        {
            return board[row, col];
        }

        public void SetFigure(int row, int col, IFigure figure)
        {
            this.board[row, col] = figure;
        }

        public abstract void InitializeStartGameBoard();

        public IFigure GetFigure(int row, int col)
        {
            var figure = this.board[row, col];
            this.board[row, col] = null;
            return figure;
        }
    }
}
