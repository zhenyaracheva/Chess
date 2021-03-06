﻿namespace Chess.Players
{
    using System;
    using System.Collections.Generic;

    using Chess.Figures;
    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Players.Common;

    public class Player : IPlayer
    {
        private const int MinNameSymbolsCount = 3;
        private const int MaxNameSymbolsCount = 15;

        private string name;
        private FigureColor color;
        private IDictionary<Position, IFigure> figures;
        private IList<IFigure> takenFigures;
        private Validator validator;

        public Player(string name, FigureColor color, State playerState)
        {
            this.validator = new Validator();
            this.Name = name;
            this.Color = color;
            this.figures = this.GetStarGameFifures();
            this.takenFigures = new List<IFigure>();
            this.PlayerState = playerState;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                validator.ValidateNullOrEmptyString(value, "Player name cannot be null or empty");
                validator.ValidRange(value.Length, Player.MinNameSymbolsCount, Player.MaxNameSymbolsCount, "Player name length must be between " + Player.MinNameSymbolsCount + " and " + Player.MaxNameSymbolsCount);

                this.name = value;
            }
        }

        public FigureColor Color
        {
            get
            {
                return this.color;
            }

            private set
            {
                this.color = value;
            }
        }

        public IDictionary<Position, IFigure> Figures
        {
            get
            {
                return new Dictionary<Position, IFigure>(this.figures);
            }
        }

        public State PlayerState { get; set; }

        public IList<IFigure> TakenFigures
        {
            get
            {
                return new List<IFigure>(this.takenFigures);
            }
        }

        public void TakeFigure(Position position, IFigure figure, IPlayer secondPlayer)
        {
            secondPlayer.RemoveFigure(position);
            this.AddFigure(position, figure);
            this.TakenFigures.Add(figure);
        }

        public void RemoveFigure(Position position)
        {
            if (this.figures.Keys.Contains(position))
            {
                this.figures.Remove(position);
            }
        }

        public void AddFigure(Position position, IFigure figure)
        {
            if (!this.figures.Keys.Contains(position))
            {
                this.figures.Add(position, figure);
            }
        }

        private IDictionary<Position, IFigure> GetStarGameFifures()
        {
            var figures = new Dictionary<Position, IFigure>();
            var figureIndex = 0;
            var direction = this.Color == FigureColor.White ? -1 : 1;
            var currentRow = this.Color == FigureColor.White ? GlobalConstants.StandatdBoardGameSize - 1 : 0;

            for (int row = 0; row < GlobalConstants.InitialRowsWithFigures; row++)
            {
                for (int col = 0; col < GlobalConstants.StandatdBoardGameSize; col++)
                {
                    var currentPositon = new Position(currentRow, col);
                    var currentFigure = (IFigure)Activator.CreateInstance(GlobalConstants.StartFigureOrderStandartGame[figureIndex], this.Color);
                    figures.Add(currentPositon, currentFigure);
                    figureIndex++;
                }

                currentRow += direction;
            }

            return figures;
        }
    }
}
