using System;
using System.Collections.Generic;
using System.Linq;
using StupidPrincess.Game.MainGame.Entities;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame
{
    public class Maze : Renderable
    {
        private readonly Size _size;
        private readonly List<IEntity> _entities = new List<IEntity>(); 

        public Maze(Size size) {
            _size = size;
        }

        public void AddEntity(IEntity entity) {
            _entities.Add(entity);
        }

        public override IEnumerable<IRenderable> Children => _entities;
        public Rectangle Bounds => new Rectangle(new Position(0, 0), _size);

        public void Update(TimeSpan deltaTime) {
            foreach (var entity in _entities) {
                entity.Update(deltaTime);
            }
        }
        
        public bool IsValidAndUnoccupied(Position newPosition)
        {
            return Bounds.Contains(newPosition) && !PlaceIsOccupied(newPosition);
        }

        public bool PlaceIsOccupied(Position position)
        {
            return Children.Any(c => c.RenderPosition == position);
        }
    }
}
