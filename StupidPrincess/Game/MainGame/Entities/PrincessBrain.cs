using System;
using System.Collections.Generic;
using System.Linq;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.Entities
{
    public class PrincessBrain
    {
        private static readonly Random _random = new Random();

        private readonly Position _previousPosition;
        private readonly Position _currentPosition;
        private readonly Maze _maze;

        public PrincessBrain(Position previousPosition, Position currentPosition, Maze maze) {
            _previousPosition = previousPosition;
            _currentPosition = currentPosition;
            _maze = maze;
        }

        public Position GetNextPosition() {
            var choices = GetChoices();
            var bestChoices = choices.Where(p => p != _previousPosition).ToList();
            if (bestChoices.Any()) {
                return bestChoices[_random.Next(bestChoices.Count)];
            }
            return choices.Contains(_previousPosition) ? _previousPosition : _currentPosition;
        }

        private IEnumerable<Position> GetChoices() {
            return new List<Position> {
                _currentPosition + Position.Right,
                _currentPosition + Position.Left,
                _currentPosition + Position.Up,
                _currentPosition + Position.Down
            }.Where(candidate => _maze.IsValidAndUnoccupied(candidate));
        }
    }
}
