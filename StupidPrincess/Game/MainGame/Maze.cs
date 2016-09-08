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

        public override Position RenderPosition => new Position(0, 2);

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
            return Bounds.Contains(newPosition) && !PlaceIsOccupiedAndSolid(newPosition);
        }

        public bool PlaceIsOccupiedAndSolid(Position position)
        {
            return _entities.Any(c => c.RenderPosition == position && c.Solid);
        }
    }
}
