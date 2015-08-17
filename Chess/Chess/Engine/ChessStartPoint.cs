namespace Chess.Engine
{
    using System;

    using Chess.Helpers;

    public class ChessStartPoint
    {
        public static void Main(string[] args)
        {
            var chessGame = new ChessStandardGame();
            chessGame.StartGame();
        }
    }
}