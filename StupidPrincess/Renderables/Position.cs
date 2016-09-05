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
    }
}