namespace Chess.Renderers
{
    using System;

    using Chess.Helpers;
    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Players.Common;
    using Chess.Renderers.Common;

    public class Renderer : IRenderer
    {
        private const int BorderSize = 3;
        private const int BoardCellSymbolsCount = 9;
        private const ConsoleColor LigthBoardCells = ConsoleColor.Yellow;
        private const ConsoleColor DarkBoardCells = ConsoleColor.Blue;
        private const char HorizontalBoardFirstSymbol = 'A';
        private const char VerticalBoardFirstSymbol = '8';

        public void PrintMessage(string message)
        {
            this.ClearConsoleInRange();
            Console.SetCursorPosition(Console.BufferWidth / 2 - message.Length/2, 0);
            Console.Write(message);
        }

        public void PrintTakeCommandMessage(IPlayer player)
        {
            this.ClearConsoleInRange();
            Console.SetCursorPosition(Console.BufferWidth / 2 - player.Name.Length, 0);
            Console.Write(player.Name + ": ");
        }

        public void ClearConsoleInRange()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.Write(" ");
            }
        }

        public void RenderBoard(IBoard board)
        {
            int counter = 0;
            int startRow = Console.BufferHeight / 2 - ((board.Size / 2) * BoardCellSymbolsCount);
            int startCol = Console.BufferWidth / 2 - ((board.Size / 2) * BoardCellSymbolsCount);

            PrintBoardBorder(startRow - Renderer.BorderSize, startCol - Renderer.BorderSize, board);

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    int printRow = startRow + row * BoardCellSymbolsCount;
                    int printCol = startCol + col * BoardCellSymbolsCount;
                    ConsoleColor color = counter % 2 == 0 ? Renderer.DarkBoardCells : Renderer.LigthBoardCells;
                    var figure = board.SeeFigureOnPosition(row, col);
                    this.PrintCell(printRow, printCol, color, figure);
                    counter++;
                }

                counter++;
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }

        private void PrintBoardBorder(int startRow, int startCol, IBoard board)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            int HorizontalBoardSymbolTopRow = (Console.BufferWidth / 2) - ((board.Size / 2) * BoardCellSymbolsCount) - 2;
            int totalBoardCols = board.Size * Renderer.BoardCellSymbolsCount;
            var totalCols = totalBoardCols + 2 * Renderer.BorderSize;
            int startBoardCol = ((Console.BufferHeight / 2) - totalCols / 2) + BoardCellSymbolsCount / 2 + Renderer.BorderSize;
            PrintBoardSide(startRow, startRow + Renderer.BorderSize, startCol, startCol + totalCols);
            PrintHorizontalSymbols(startBoardCol, totalBoardCols, HorizontalBoardSymbolTopRow, board, Renderer.HorizontalBoardFirstSymbol);

            int HorizontalBoardSymbolBottomRow = (Console.BufferWidth / 2) + ((board.Size / 2) * BoardCellSymbolsCount) + 1;
            var bottomStartRow = Console.BufferHeight / 2 + (board.Size / 2 * Renderer.BoardCellSymbolsCount);
            PrintBoardSide(bottomStartRow, bottomStartRow + Renderer.BorderSize, startCol, startCol + totalCols);
            PrintHorizontalSymbols(startBoardCol, totalBoardCols, HorizontalBoardSymbolBottomRow, board, Renderer.HorizontalBoardFirstSymbol);

            int totalBoardRows = board.Size * BoardCellSymbolsCount;
            int varticalBoardSymbolLeftCol = (Console.BufferHeight / 2) - ((board.Size / 2) * BoardCellSymbolsCount) - 2;
            var totalRows = board.Size * Renderer.BoardCellSymbolsCount + Renderer.BorderSize;
            int startBoardRow = ((Console.BufferHeight / 2) - totalCols / 2) + BoardCellSymbolsCount / 2 + Renderer.BorderSize;
            PrintBoardSide(startRow, startRow + totalRows, startCol, startCol + Renderer.BorderSize);
            PrintVerticalSymbols(startBoardRow, totalBoardRows, varticalBoardSymbolLeftCol, board, Renderer.VerticalBoardFirstSymbol);

            var rigthBorderStartCol = Console.BufferWidth / 2 + (board.Size * Renderer.BoardCellSymbolsCount / 2);
            int varticalBoardSymbolRigthCol = (Console.BufferHeight / 2) + ((board.Size / 2) * BoardCellSymbolsCount) + 1;
            PrintBoardSide(startRow, startRow + totalRows, rigthBorderStartCol, rigthBorderStartCol + Renderer.BorderSize);
            PrintVerticalSymbols(startBoardRow, totalBoardRows, varticalBoardSymbolRigthCol, board, Renderer.VerticalBoardFirstSymbol);
        }

        private void PrintHorizontalSymbols(int startCol, int totalCols, int HorizontalBoardSymbolTopRow, IBoard board, char symbol)
        {
            for (int i = startCol; i < startCol + totalCols; i += BoardCellSymbolsCount)
            {
                Console.SetCursorPosition(i, HorizontalBoardSymbolTopRow);
                Console.Write(symbol);
                symbol++;
            }
        }

        private void PrintVerticalSymbols(int startRow, int totalRows, int verticalBoardSymbolTopCol, IBoard board, char symbol)
        {
            for (int i = startRow; i < startRow + totalRows; i += BoardCellSymbolsCount)
            {
                Console.SetCursorPosition(verticalBoardSymbolTopCol, i);
                Console.Write(symbol);
                symbol--;
            }
        }

        private void PrintBoardSide(int startRow, int endRow, int startCol, int endCol)
        {
            var middleCol = (endCol - startCol) / 2;
            for (int row = startRow; row < endRow; row++)
            {
                Console.SetCursorPosition(startCol, row);
                for (int col = startCol; col < endCol; col++)
                {
                    Console.Write(" ");
                }
            }
        }

        private void PrintCell(int row, int col, ConsoleColor color, IFigure figure)
        {
            for (int i = row, figureRow = 0; i < row + BoardCellSymbolsCount; i++, figureRow++)
            {
                for (int j = col, figureCol = 0; j < col + BoardCellSymbolsCount; j++, figureCol++)
                {
                    Console.BackgroundColor = color;
                    Console.SetCursorPosition(j, i);

                    if (figure != null)
                    {
                        var figurePattern = ConsoleHelper.Patterns[figure.Type];
                        if (figurePattern[figureRow, figureCol])
                        {
                            Console.BackgroundColor = (ConsoleColor)figure.Color;
                        }
                    }

                    Console.Write(" ");
                }
            }
        }
    }
}