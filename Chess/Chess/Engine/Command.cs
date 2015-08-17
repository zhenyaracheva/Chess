namespace Chess.Engine
{
    using System;

    using Chess.Helpers;
    using Chess.Board.Common;

    public static class Command
    {
        private const int CharTransformer = 96;

        public static Move ParseCommand(string command, IBoard board)
        {
            var parsedCommand = command.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            var currentPositionRow = GetPositionValue(parsedCommand[0][1], board);
            var currentPositionCol = GetPositionValue(parsedCommand[0][0], board);
            var from = new Position(currentPositionRow, currentPositionCol);

            var nextPositionRow = GetPositionValue(parsedCommand[1][1], board);
            var nextPositionCol = GetPositionValue(parsedCommand[1][0], board);
            var to = new Position(nextPositionRow, nextPositionCol);

            return new Move(from,to);
        }

        private static int GetPositionValue(char value, IBoard board)
        {
            if (char.IsDigit(value))
            {
                return board.Size - int.Parse(value.ToString());
            }
            else
            {
                var lowerCaseLetter = value.ToString().ToLower()[0];
                return lowerCaseLetter - Command.CharTransformer - 1;
            }
        }
    }
}
