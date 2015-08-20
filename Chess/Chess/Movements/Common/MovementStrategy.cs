namespace Chess.Movements.Common
{
    using System.Collections.Generic;

    using Chess.Figures.Common;
    using Chess.Helpers;
    using Chess.Movements;

    public class MovementStrategy : IMovementStrategy
    {
        private readonly IDictionary<FigureType, IList<IMovement>> movements = new Dictionary<FigureType, IList<IMovement>>
        {
            { FigureType.Pawn, new List<IMovement>
                 {
                     new PawnMovement()
                 } 
            }, 
            { FigureType.Rook, new List<IMovement>
                 {
                     new RookMovement()
                 } 
            },
             { FigureType.Bishop, new List<IMovement>
                 {
                     new BishopMovement()
                 } 
            },
             { FigureType.Knight, new List<IMovement>
                 {
                     new KnightMovement()
                 } 
            },
             { FigureType.King, new List<IMovement>
                 {
                     new KingMovement()
                 } 
            },
             { FigureType.Queen, new List<IMovement>
                 {
                     new RookMovement(),
                     new BishopMovement()
                 } 
            },
        };

        public ICollection<IMovement> Moves(FigureType figureType)
        {
            return this.movements[figureType];
        }
    }
}