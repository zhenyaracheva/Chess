namespace Chess.Helpers
{
    public class Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public override int GetHashCode()
        {
            return this.Row << this.Col;
        }

        public override bool Equals(object obj)
        {
            var position = obj as Position;

            if (this.Row == position.Row && this.Col == position.Col)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
