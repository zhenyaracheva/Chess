namespace Chess.Engine
{
    public class ChessStartPoint
    {
        public static void Main(string[] args)
        {
            var chessGame = new ChessStandardGame();
            chessGame.StartGame();
        }
    }
}