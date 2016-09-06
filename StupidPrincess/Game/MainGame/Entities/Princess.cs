using System;
using System.Collections.Generic;
using System.Linq;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.Entities
{
    public class Princess : IEntity
    {
        private Position _position;
        private readonly Maze _maze;

        public Princess(Position startingPosition, Maze maze) {
            _position = startingPosition;
            _maze = maze;
        }

        public string RenderedText => "P";
        public ConsoleColor RenderedColor => ConsoleColor.Magenta;
        public ConsoleColor BackgroundColor => ConsoleColor.Black;

        public Position RenderPosition => _position;
        public IEnumerable<IRenderable> Children => new IRenderable[0];

        private TimeSpan _timeUntilUpdate = TimeSpan.Zero;
        private static readonly TimeSpan UpdatePeriod = TimeSpan.FromSeconds(.25);
        public void Update(TimeSpan deltaTime) {
            _timeUntilUpdate -= deltaTime;
            if (_timeUntilUpdate.TotalSeconds > 0) return;
            _timeUntilUpdate = UpdatePeriod;

            DoUpdate();
        }

        private readonly Random _random = new Random();

        private void DoUpdate() {
            var newX = _position.X + _random.Next(-1, 2);
            var newY = _position.Y + _random.Next(-1, 2);

            var newPosition = new Position(newX, newY);
            if (_maze.Bounds.Contains(newPosition) && !PlaceIsOccupied(newPosition)) {
                _position = newPosition;
            }
        }

        private bool PlaceIsOccupied(Position newPosition) {
            return _maze.Children.Any(c => c.RenderPosition == newPosition);
        }
    }
}
