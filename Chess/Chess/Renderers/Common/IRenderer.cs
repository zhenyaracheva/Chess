namespace Chess.Renderers.Common
{
    using Chess.Board.Common;
    using Chess.Players;
    using Chess.Players.Common;

    public interface IRenderer
    {
        void RenderBoard(IBoard board);

        void PrintMessage(string message);

        void PrintTakeCommandMessage(IPlayer player);

        void ClearConsoleInRange();
    }
}
