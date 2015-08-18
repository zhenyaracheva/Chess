namespace Chess.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Chess.Helpers;
    using Chess.Movements;
    using Chess.Board;
    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Movements.Common;
    using Chess.Players;
    using Chess.Players.Common;
    using Chess.Renderers.Common;
    using Chess.Renderers;

    public class ChessStandardGame
    {
        private readonly IRenderer renderer;
        private readonly IBoard gameBoard;
        private readonly IPlayer whitePlayer;
        private readonly IPlayer blackPlayer;
        private readonly IMovementStrategy strategy;

        public ChessStandardGame()
        {
            this.gameBoard = new StandardBoardGame();
            this.whitePlayer = new Player("White Player", FigureColor.White, State.OnTheMove);
            this.blackPlayer = new Player("Black Player", FigureColor.Black, State.NotOnTheMove);
            this.renderer = new Renderer();
            this.strategy = new MovementStrategy();
        }

        public void StartGame()
        {
            this.PlayChess();
        }

        private void PlayChess()
        {
            while (true)
            {
                try
                {
                    renderer.RenderBoard(gameBoard);
                    var attacker = GetAttacker(whitePlayer, blackPlayer);
                    var defender = GetDefender(whitePlayer, blackPlayer);

                    renderer.PrintTakeCommandMessage(attacker);
                    var currentCommad = Console.ReadLine();
                    var move = Command.ParseCommand(currentCommad, gameBoard);

                    this.CheckPlayerContainsFigure(attacker, move.From);
                    this.CheckIfToPositionIsTakenByAttacker(attacker, move.To);

                    var playFigure = gameBoard.SeeFigureOnPosition(move.From.Row, move.From.Col);

                    var availableMovements = playFigure.Move(this.strategy);
                    this.CheckValidMove(playFigure, availableMovements, move);

                    this.TakeDefenderFigure(attacker, defender, move, gameBoard);


                    this.MoveFigures(move, playFigure);

                    attacker.RemoveFigure(move.From);
                    attacker.AddFigure(move.To, playFigure);
                    TogglePlayerState(whitePlayer);
                    TogglePlayerState(blackPlayer);
                }
                catch (Exception ex)
                {
                    renderer.PrintMessage(ex.Message);
                    Thread.Sleep(1000);
                }
            }
        }

        private void MoveFigures(Move move, IFigure playFigure)
        {
            this.gameBoard.GetFigure(move.From.Row, move.From.Col);
            this.gameBoard.SetFigure(move.To.Row, move.To.Col, playFigure);
        }

        private void TakeDefenderFigure(IPlayer attacker, IPlayer defender, Move move, IBoard gameBoard)
        {
            var figure = gameBoard.SeeFigureOnPosition(move.To.Row, move.To.Col);
            if (figure != null)
            {
                attacker.TakeFigure(move.To, figure, defender);
            }
        }

        private void CheckValidMove(IFigure playFigure, ICollection<IMovement> availableMovements, Move move)
        {
            foreach (var movement in availableMovements)
            {
                movement.ValidateMove(playFigure, this.gameBoard, move);
            }
        }

        private void CheckIfToPositionIsTakenByAttacker(IPlayer attacker, Position to)
        {
            var figureAtPosition = this.gameBoard.SeeFigureOnPosition(to.Row, to.Col);
            if (figureAtPosition != null && figureAtPosition.Color == attacker.Color)
            {
                throw new InvalidOperationException("You already have figure on that position!");
            }
        }

        private void CheckPlayerContainsFigure(IPlayer attacker, Position position)
        {
            if (!attacker.Figures.Keys.Contains(position))
            {
                throw new ArgumentException("Figure is not yours!");
            }
        }

        private void TogglePlayerState(IPlayer player)
        {
            if (player.PlayerState == State.OnTheMove)
            {
                player.PlayerState = State.NotOnTheMove;
            }
            else
            {
                player.PlayerState = State.OnTheMove;
            }
        }

        private IPlayer GetAttacker(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            if (firstPlayer.PlayerState == State.OnTheMove)
            {
                return firstPlayer;
            }
            else
            {
                return secondPlayer;
            }
        }

        private IPlayer GetDefender(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            if (firstPlayer.PlayerState == State.NotOnTheMove)
            {
                return firstPlayer;
            }
            else
            {
                return secondPlayer;
            }
        }
    }
}