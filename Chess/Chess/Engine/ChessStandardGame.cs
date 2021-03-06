﻿namespace Chess.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Chess.Board;
    using Chess.Board.Common;
    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Movements.Common;
    using Chess.Players;
    using Chess.Players.Common;
    using Chess.Renderers;
    using Chess.Renderers.Common;

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
                    this.renderer.RenderBoard(this.gameBoard);
                    var attacker = this.GetPlayerByState(this.whitePlayer, this.blackPlayer, State.OnTheMove);
                    var defender = this.GetPlayerByState(this.whitePlayer, this.blackPlayer, State.NotOnTheMove);

                    this.renderer.PrintTakeCommandMessage(attacker);
                    var currentCommad = Console.ReadLine();
                    var move = Command.ParseCommand(currentCommad, this.gameBoard);

                    this.CheckPlayerContainsFigure(attacker, move.From);
                    this.CheckIfToPositionIsTakenByAttacker(attacker, move.To);

                    var kingPosition = this.FindKingPosition(attacker);
                    if (kingPosition == null)
                    {
                        Console.Clear();
                        Console.WriteLine("GAME OVER!");
                        break;
                    }

                    var playFigure = this.gameBoard.SeeFigureOnPosition(move.From.Row, move.From.Col);

                    // try use attacker.Figures instead of gameBoard!
                    if (this.CheckIfCheck(this.gameBoard, kingPosition, defender.Figures))
                    {
                        this.CheckIfToPositionSafeKing(attacker, playFigure, move, gameBoard, kingPosition, defender.Figures);
                    }

                    var availableMovements = playFigure.Move(this.strategy);
                    this.CheckValidMove(playFigure, availableMovements, move);
                    this.TakeDefenderFigure(attacker, defender, move, this.gameBoard);
                    this.MoveFigures(move, playFigure);

                    if (playFigure.Type == FigureType.King &&
                        ((move.From.Col + 2) == move.To.Col || (move.From.Col - 2 == move.To.Col)))
                    {
                        MoveRookCastle(move, attacker);
                    }

                    attacker.RemoveFigure(move.From);
                    attacker.AddFigure(move.To, playFigure);

                    /// TODO:
                    /// En passant
                    /// Promotion
                    /// End of the game
                    /// - Win/Lose
                    /// - Draw
                    /// If you have nothing else to do: Time control

                    this.TogglePlayerState(this.whitePlayer);
                    this.TogglePlayerState(this.blackPlayer);
                }
                catch (Exception ex)
                {
                    this.renderer.PrintMessage(ex.Message);
                    Thread.Sleep(1000);
                }
            }
        }

        private void MoveRookCastle(Move move, IPlayer attacker)
        {
            var isLongCastle = move.From.Col > move.To.Col;
            var rookRow = move.From.Row;
            var rookFromCol = isLongCastle ? 0 : 7;
            var rookToCol = isLongCastle ? move.From.Col - 1 : move.From.Col + 1;
            var rook = this.gameBoard.SeeFigureOnPosition(rookRow, rookFromCol);

            var rookFromPosition = new Position(rookRow, rookFromCol);
            var rookToPosition = new Position(rookRow, rookToCol);
            var rookMove = new Move(rookFromPosition, rookToPosition);

            this.MoveFigures(rookMove, rook);
            attacker.RemoveFigure(rookMove.From);
            attacker.AddFigure(rookMove.To, rook);
        }

        private void CheckIfToPositionSafeKing(IPlayer attacker, IFigure playFigure, Move move, IBoard gameBoard, Position kingPosition, IDictionary<Position, IFigure> defenderFigures)
        {
            var toFigure = gameBoard.SeeFigureOnPosition(move.To.Row, move.To.Col);
            gameBoard.SetFigure(move.To.Row, move.To.Col, playFigure);
            gameBoard.SetFigure(move.From.Row, move.From.Col, null);
            kingPosition = this.FindKingPosition(attacker);

            if (this.CheckIfCheck(gameBoard, kingPosition, defenderFigures))
            {
                gameBoard.SetFigure(move.To.Row, move.To.Col, toFigure);
                gameBoard.SetFigure(move.From.Row, move.From.Col, playFigure);

                throw new InvalidOperationException("Under Chess Save Your King!");
            }

            gameBoard.SetFigure(move.To.Row, move.To.Col, toFigure);
            gameBoard.SetFigure(move.From.Row, move.From.Col, playFigure);
        }

        private bool CheckIfCheck(IBoard gameBoard, Position kingPosition, IDictionary<Position, IFigure> defenderFigures)
        {
            var defenderFiguresPositions = defenderFigures.Keys;
            var counter = 0;

            foreach (var position in defenderFiguresPositions)
            {
                var figure = defenderFigures[position];
                var availableMovements = figure.Move(this.strategy);

                try
                {
                    var tryMove = new Move(position, kingPosition);
                    this.CheckValidMove(figure, availableMovements, tryMove);
                }
                catch (Exception ex)
                {
                    counter++;
                }
            }
            if (counter == defenderFigures.Count)
            {
                return false;
            }

            return true;
        }

        private Position FindKingPosition(IPlayer attacker)
        {
            var keys = attacker.Figures.Keys;
            Position kingPosition = null;

            foreach (var key in keys)
            {
                if (attacker.Figures[key].Type == FigureType.King)
                {
                    kingPosition = key;
                }
            }

            return kingPosition;
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
            var validMove = false;
            var fountExeprition = new Exception();

            foreach (var movement in availableMovements)
            {
                try
                {
                    movement.ValidateMove(playFigure, this.gameBoard, move);
                    validMove = true;
                    break;
                }
                catch (Exception ex)
                {
                    fountExeprition = ex;
                }
            }

            if (!validMove)
            {
                throw fountExeprition;
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

        private IPlayer GetPlayerByState(IPlayer firstPlayer, IPlayer secondPlayer, State state)
        {
            if (firstPlayer.PlayerState == state)
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