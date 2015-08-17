﻿namespace Chess.Helpers
{
    using System;
    using System.Collections.Generic;

    using Chess.Figures;

    public class GlobalConstants
    {
        public const int StandatdBoardGameSize = 8;
        public const int InitialRowsWithFigures = 2;
        public static readonly IList<Type> StartFigureOrderStandartGame = new List<Type>
                                            {
                                                typeof(Rook),
                                                typeof(Knight),
                                                typeof(Bishop), 
                                                typeof(Queen),
                                                typeof(King),
                                                typeof(Bishop),
                                                typeof(Knight),
                                                typeof(Rook),
                                                typeof(Pawn),
                                                typeof(Pawn),
                                                typeof(Pawn),
                                                typeof(Pawn),
                                                typeof(Pawn),
                                                typeof(Pawn),
                                                typeof(Pawn),
                                                typeof(Pawn),
                                            };
    }
}
