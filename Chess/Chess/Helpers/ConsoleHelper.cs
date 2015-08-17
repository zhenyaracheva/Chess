﻿namespace Chess.Helpers
{
    using Chess.Figures.Common;
    using System.Collections.Generic;

    public static class ConsoleHelper
    {
        public static readonly IDictionary<FigureType, bool[,]> Patterns = new Dictionary<FigureType, bool[,]>
        {
            { FigureType.Pawn, new[,]
                {
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, false, false, true, false, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, false, false, true, false, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, false, false, false, false, false, false, false, }
                } 
            },
            { FigureType.Rook, new[,]
                {
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, true, false, true, false, true, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, false, false, false, false, false, false, false, }
                }
            },
            { FigureType.Knight, new[,]
                {
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, false, false, true, true, false, false, false, },
                    { false, false, false, true, true, true, true, false, false, },
                    { false, false, true, true, true, false, true, false, false, },
                    { false, false, false, true, false, true, true, false, false, },
                    { false, false, false, false, true, true, true, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, false, false, false, false, false, false, false, }
                } 
            },
            { FigureType.Bishop, new[,]
                {
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, false, false, true, false, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, false, true, true, false, true, true, false, false, },
                    { false, false, true, false, false, false, true, false, false, },
                    { false, false, false, true, false, true, false, false, false, },
                    { false, false, false, false, true, false, false, false, false, },
                    { false, true, true, true, false, true, true, true, false, },
                    { false, false, false, false, false, false, false, false, false, }
                }
            },
            { FigureType.King, new[,]
                {
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, false, false, true, false, false, false, false, },
                    { false, false, false, true, true, true, false, false, false, },
                    { false, true, true, false, true, false, true, true, false, },
                    { false, true, true, true, false, true, true, true, false, },
                    { false, true, true, true, true, true, true, true, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, false, false, false, false, false, false, false, }
                } 
            },
            {FigureType.Queen, new[,]
                {
                    { false, false, false, false, false, false, false, false, false, },
                    { false, false, false, false, true, false, false, false, false, },
                    { false, false, true, false, true, false, true, false, false, },
                    { false, false, false, true, false, true, false, false, false, },
                    { false, true, false, true, true, true, false, true, false, },
                    { false, false, true, false, true, false, true, false, false, },
                    { false, false, true, true, false, true, true, false, false, },
                    { false, false, true, true, true, true, true, false, false, },
                    { false, false, false, false, false, false, false, false, false, }
                } 
            }
        };
    }
}