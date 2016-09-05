using System;
using System.Collections.Generic;
using StupidPrincess.Game.MainGame.Entities;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame
{
    public class Maze : Renderable
    {
        private Size _size;
        private readonly List<IEntity> _entities = new List<IEntity>(); 

        public Maze(Size size) {
            _size = size;
        }

        public void AddEntity(IEntity entity) {
            _entities.Add(entity);
        }

        public override IEnumerable<IRenderable> Children => _entities;

        public void Update(TimeSpan deltaTime) {
            foreach (var entity in _entities) {
                entity.Update(deltaTime);
            }
        }
    }
}
