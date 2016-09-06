namespace StupidPrincess.Renderables
{
    public class Rectangle
    {
        private readonly Position _position;
        private readonly Size _size;

        public Rectangle(Position position, Size size) {
            _size = size;
            _position = position;
        }

        public bool Contains(Position newPosition) {
            return newPosition.X >= _position.X && newPosition.Y >= _position.Y
                   && newPosition.X <= _position.X + _size.Width 
                   && newPosition.Y <= _position.Y + _size.Height;
        }
    }
}