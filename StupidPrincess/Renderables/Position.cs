namespace StupidPrincess.Renderables
{
    public class Position
    {
        public Position(int x, int y) {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }

        public static Position operator +(Position left, Position right) {
            return new Position(left.X + right.X, left.Y + right.Y);
        }

        #region Equals

        public static bool operator ==(Position left, Position right) {
            return ReferenceEquals(left, right) || (!ReferenceEquals(left, null) && left.Equals(right));
        }

        public static bool operator !=(Position left, Position right) {
            return !(left == right);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as Position;
            return !ReferenceEquals(other, null) && Equals(other);
        }

        protected bool Equals(Position other) {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(other, null)) return false;

            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode() {
            return X.GetHashCode() + Y.GetHashCode();
        }

        #endregion
    }
}