using System;
using StupidPrincess.Renderables;

namespace StupidPrincess.Game
{
    public interface ISubstate : IRenderable
    {
        void Update(TimeSpan deltaTime);
    }
}
