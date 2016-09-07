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

        private void DoUpdate()
        {
            var pastPosition = _position;

            var newPosition = GetNewPosition(pastPosition);
            if (_maze.Bounds.Contains(newPosition) && !PlaceIsOccupied(newPosition)) {
                _position = newPosition;
            }
        }

        private bool PlaceIsOccupied(Position newPosition) {
            return _maze.Children.Any(c => c.RenderPosition == newPosition);
        }

        private string GetDirection(Position pastPosition)
        {
            if (pastPosition == _position) return "start";
            else if (pastPosition.X < _position.X && pastPosition.Y == _position.Y)
            {
                return "right";
            }
            else if (pastPosition.X > _position.X && pastPosition.Y == _position.Y)
            {
                return "left";
            }
            else if (pastPosition.Y < _position.Y && pastPosition.X == _position.X)
            {
                return "up";
            }
            else
            {
                return "down";
            }
        }

        private Position MoveDown()
        {
            return new Position(_position.X, _position.Y - 1);
        }
        private Position MoveUp()
        {
            return new Position(_position.X, _position.Y + 1);
        }
        private Position MoveLeft()
        {
            return new Position(_position.X - 1, _position.Y);
        }
        private Position MoveRight()
        {
            return new Position(_position.X + 1, _position.Y);
        }
        private Position GetNewPosition(Position pastPosition)
        {
            if (GetDirection(pastPosition).Equals("start") || GetDirection(pastPosition).Equals("right"))
            {
                return MoveRight();
            }
            else if (GetDirection(pastPosition).Equals("left"))
            {
                return MoveLeft();
            }
            else if (GetDirection(pastPosition).Equals("up"))
            {
               return MoveUp();
            }
            else
            {
                return MoveDown();
            }
        }

        private int NumberOfDecisions(Position pastPosition)
        {
            if (GetDirection(pastPosition).Equals("left") && PlaceIsOccupied(MoveUp()) && PlaceIsOccupied(MoveDown()) && !PlaceIsOccupied(MoveRight()))
            {
                return 1;
            }
            else if (GetDirection(pastPosition).Equals("right") && PlaceIsOccupied(MoveUp()) && PlaceIsOccupied(MoveDown()) && !PlaceIsOccupied(MoveLeft()))
            {
                return 1;
            }
            else if (GetDirection(pastPosition).Equals("up") && PlaceIsOccupied(MoveLeft()) && PlaceIsOccupied(MoveRight()) && !PlaceIsOccupied(MoveDown()))
            {
                return 1;
            }
            else if (GetDirection(pastPosition).Equals("down") && PlaceIsOccupied(MoveLeft()) && PlaceIsOccupied(MoveRight()) && !PlaceIsOccupied(MoveUp()))
            {
                return 1;
            }
            else
            {
                
            }
        }
        private Position MakeDecison(Position pastPosition)
        {
            
        }

    }
}
