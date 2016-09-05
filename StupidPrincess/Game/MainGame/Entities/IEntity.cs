using System;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game.MainGame.Entities
{
    public interface IEntity : IRenderable
    {
        void Update(TimeSpan deltaTime);
    }
}
