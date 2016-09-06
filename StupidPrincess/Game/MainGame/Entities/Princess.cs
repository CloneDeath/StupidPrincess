using System;
using System.Collections.Generic;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.Entities
{
    public class Princess : IEntity
    {
        private Position _previousPosition;
        private Position _position;
        private readonly Maze _maze;

        public Princess(Position startingPosition, Maze maze) {
            _previousPosition = startingPosition;
            _position = startingPosition;
            _maze = maze;
        }

        public string RenderedText => "P";
        public ConsoleColor RenderedColor => ConsoleColor.Magenta;
        public ConsoleColor BackgroundColor => ConsoleColor.Black;

        public Position RenderPosition => _position;
        public IEnumerable<IRenderable> Children => new IRenderable[0];

        private TimeSpan _timeUntilUpdate = TimeSpan.Zero;
        private static readonly TimeSpan _updatePeriod = TimeSpan.FromSeconds(.25);

        public void Update(TimeSpan deltaTime) {
            _timeUntilUpdate -= deltaTime;
            if (_timeUntilUpdate.TotalSeconds > 0) return;
            _timeUntilUpdate = _updatePeriod;

            MovePrincess();
        }

        private void MovePrincess()
        {
            var newPosition = GetNewPosition();
            if (_maze.IsValidAndUnoccupied(newPosition)) {
                _previousPosition = _position;
                _position = newPosition;
            }
        }

        private Position GetNewPosition() {
            var brain = new PrincessBrain(_previousPosition, _position, _maze);
            return brain.GetNextPosition();
        }
    }
}
